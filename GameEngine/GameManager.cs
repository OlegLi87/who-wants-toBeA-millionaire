using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsContainerLibrary;
using Quest;

namespace GameEngine
{
    public static class GameManager
    {
        private static string _gameStatus = "OFF";
        private static GameSession newGame;
        private static AnswersShuffle shuffle;
        private static int timesGameRenewed = 0;
        public static bool AllowedToEnterTheGame { private get; set; }

        public static void TurnMeOn()
        {
                FlowControl();                     
        }

        static GameManager()
        {
            _gameStatus = "ON";
            AllowedToEnterTheGame = true;
            shuffle = new AnswersShuffle();
        }

        private static void FlowControl()
        {
            PrintingEngine.WelcomeMessagePrint();

            newGame = new GameSession(QuestionsStash.SetQuestAnswer());  //Creating new Session with QuestionAnswer List
            shuffle.SfuffleQuestion<GeneralQuestion>(newGame.QuestionAnswerList);   //Shuffling question list for each session           

            if (!AllowedToEnterTheGame) return;

            PrintingEngine.GameIsReady();

            while (!newGame.GameOver)
            {
                GeneralQuestion currentQuestion = TakeQuestion(); //Getting Question for current stage of the game. 
                Array.Sort(currentQuestion.Answers, shuffle);     //Shuffling answers

                PrintingEngine.PrintSessionInfo(newGame);
                PrintingEngine.PrintQuestion(currentQuestion,newGame.HelpsRemained);

                Console.ResetColor();
                Console.SetCursorPosition(100, 45);
                bool isRight = CompareAnswers(Console.ReadLine(), currentQuestion);
                MakeChanges(isRight,currentQuestion);
            }    
                   
            if (newGame.CurrentQuestion == 15)
            {
                PrintingEngine.PrintSessionInfo(newGame);
                PrintingEngine.YouAre_Millionaire();
            }

            else PrintingEngine.PrintGameOver();
        }

        private static bool CompareAnswers(string answer,GeneralQuestion currentQuestion)
        {
            if (Convert.ToInt32(answer) == 5 && newGame.HelpsRemained != 0)
            {
                Random rand = new Random();
                int count = 0;
                  
                newGame.HelpsRemained = 0;
                while(count < 2)
                {
                    int index = rand.Next(0,3);

                    if (currentQuestion.Answers[index] != currentQuestion.RightAnswer && currentQuestion.Answers[index] != "")
                    {
                        currentQuestion.Answers[index] = "";
                        count++;
                    }                
                }               
                PrintingEngine.PrintSessionInfo(newGame);
                PrintingEngine.PrintQuestion(currentQuestion, newGame.HelpsRemained);
                Console.ResetColor();
                Console.SetCursorPosition(100, 45);
                return CompareAnswers(Console.ReadLine(), currentQuestion);
            }
            else if (currentQuestion.Answers[int.Parse(answer) - 1] == currentQuestion.RightAnswer) return true;
            
            else return false;        
        }

        private static void MakeChanges(bool isRight,GeneralQuestion currentQuestion)   // Will make a change in Session Instance
        {
            if (isRight)
            {
                if (newGame.CurrentQuestion == 15)
                {
                    newGame.GameOver = true;
                    newGame.CurrentScore = 1000000;
                } 
                else
                {
                    PrintingEngine.PrintWinningBill();
                    if (currentQuestion is EasyQuestion) newGame.CurrentScore += 10000;
                    else if (currentQuestion is MediumQuestion) newGame.CurrentScore += 70000;
                    else newGame.CurrentScore += 120000;

                    newGame.CurrentQuestion++;
                }
            }
            else
            {
                if (newGame.CurrentScore >= 50000 && timesGameRenewed == 0)
                {
                    PrintingEngine.AskToContinue(currentQuestion);                  
                    ConsoleKeyInfo choice = Console.ReadKey();

                    if (choice.KeyChar == 'y')
                    {
                        newGame.CurrentQuestion = 3;
                        newGame.CurrentScore = 30000;
                        timesGameRenewed++;
                    }
                    else
                    {
                        newGame.GameOver = true;
                        newGame.CurrentScore = 50000;
                    }                    
                }                       
                 else newGame.GameOver = true;                
            }          
        }   
        /// <summary>
        /// Here i taking out question from the list according to current stage in game session.
        /// </summary>
        /// <returns></returns>
        private static GeneralQuestion TakeQuestion()
        {
            int index = 0;

                foreach (var element in newGame.QuestionAnswerList)
                { 
                    if (newGame.CurrentQuestion < 6 && element is EasyQuestion)
                    {
                        newGame.QuestionAnswerList.RemoveAt(index);
                        return element;
                    }
                    else if ((newGame.CurrentQuestion > 5 && newGame.CurrentQuestion <= 10) && element is MediumQuestion)
                    {
                        newGame.QuestionAnswerList.RemoveAt(index);                      
                        return element;
                    }
                    else if ((newGame.CurrentQuestion > 10 && newGame.CurrentQuestion <= 15) && element is HardQuestion)
                    {
                        newGame.QuestionAnswerList.RemoveAt(index);
                        return element;
                    }
                    index++;
                }
                                         
            return null;//Actually can't reach this place
        }
    }
}
