using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quest;


namespace GameEngine
{
    public struct Player
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Player(object obj)
        {
            PrintingEngine.AskForData("Name");
            this.Name = Console.ReadLine();
            PrintingEngine.AskForData("Surname");
            this.Surname = (Console.ReadLine());
            PrintingEngine.AskForData("Age");
            this.Age = ErrorsCheckig.CheckingAgeInput();  
        }      
    } 

    public class GameSession
    {       
        private static int _sessionNumber = 0;
       
        public List<GeneralQuestion> QuestionAnswerList { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public int CurrentScore { get; set; }
        public byte HelpsRemained { get; set; }
        public byte CurrentQuestion { get; set; }
        public bool GameOver { get; set; }

        public GameSession(List<GeneralQuestion> questList)
         {
            CurrentPlayer = new Player(null);
            this.QuestionAnswerList = new List<GeneralQuestion>(questList);                   
            this.CurrentScore = 0;
            this.HelpsRemained = 1;
            this.CurrentQuestion = 1;
            this.GameOver = false;
            _sessionNumber++;
        }

        public int GetSessionsTotal()
        {
            return _sessionNumber;
        }
    }
}
