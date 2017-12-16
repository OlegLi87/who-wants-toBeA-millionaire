using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using FormsContainerLibrary;
using Quest;
using System.Threading;


namespace GameEngine
{
    public static class PrintingEngine
    {
        private static ConsoleColor[] _colors;
        private static Random _rand;
        private static int _cursorPositionWidth;
        private static int _cursorPositionHeight;
        private static readonly int _screenHeight;
        private static readonly int _screenWidth;
        private static int _count;
           
        static PrintingEngine()
        {
            _colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.DarkYellow, ConsoleColor.Magenta, ConsoleColor.White };
            _rand = new Random();
            _screenWidth = 199;
            _screenHeight = 60;
            _count = 0;
        }

        public static void WelcomeMessagePrint()
        {
            Console.SetWindowSize(_screenWidth, _screenHeight);
            MillionairePrint();
            Console.ResetColor();
            PrintBill();
        }

        static void MillionairePrint()
        {
            short timeOut = 5;
            int height = 0;

            for (int i = 0; i < _colors.Length * 3; i++)
            {

                foreach (var line in FormsContainer.Millionaire)
                {
                    Console.SetCursorPosition(0, height++);
                    Console.ForegroundColor = _colors[_rand.Next(0, _colors.Length - 1)];
                    Console.WriteLine(line);
                    Wait(timeOut);
                }

                if (i == _colors.Length * 3 - 1) break;
                timeOut += 1;
                height = 0;
            }

            Wait(100);
            Console.Clear();
            Blink(FormsContainer.Millionaire);
        }

        static void PrintBill()
        {
            int width = 89, widthIncrement = 11;
            int tempWidth = width;
            int height;

            for (int i = 0; i < 9; i++)
            {
                height = 12;
                width = tempWidth - widthIncrement * i;

                for (int k = 0; k < 2; k++)
                {
                    height = 12;
                    if (i % 2 == 0)
                    {
                        if (k == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                        else Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if (k == 1) Console.ForegroundColor = ConsoleColor.DarkGreen;
                        else Console.ForegroundColor = ConsoleColor.White;

                    }
                    foreach (var line in FormsContainer.Bill)
                    {
                        Console.SetCursorPosition(width, height++);
                        Console.WriteLine(line);
                    }

                    width = tempWidth + widthIncrement * (i + 1);
                }
                Wait(150);
            }

            height = 1;
            width = 1;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0) Console.ForegroundColor = ConsoleColor.White;
                else Console.ForegroundColor = ConsoleColor.DarkGreen;

                foreach (var line in FormsContainer.Bill)
                {
                    Console.SetCursorPosition(width, height++);
                    Console.WriteLine(line);
                }
                height = 1;
                width = 188;
            }
        }

        public static void AskForData(params string[] arr)
        {
            if (_count == 0)
            {
                Wait(1500);
                _count++;
            }
            else Wait(300);

            _cursorPositionWidth = 74;
            _cursorPositionHeight = 27;
            int heigth = 25;

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var line in FormsContainer.LargeBox)
            {
                Console.SetCursorPosition(70, heigth++);
                Console.WriteLine(line);
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(_cursorPositionWidth + 10, _cursorPositionHeight++);
            Console.WriteLine("Wanna Be A Millionaire???");
            Console.SetCursorPosition(_cursorPositionWidth, _cursorPositionHeight++);
            Console.WriteLine("First We Need To Gather Some Info About You..");

            if (arr[0] == "Name")
            {
                Console.SetCursorPosition(_cursorPositionWidth + 1, _cursorPositionHeight + 2);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your First Name : ");
                Console.ResetColor();
                return;
            }
            else if (arr[0] == "Surname")
            {
                Console.SetCursorPosition(_cursorPositionWidth + 1, _cursorPositionHeight + 2);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your Last Name : ");
                Console.ResetColor();
                return;
            }
            else if (arr[0] == "Age")
            {
                Console.SetCursorPosition(_cursorPositionWidth + 1, _cursorPositionHeight + 2);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter your Age : ");
                Console.ResetColor();
                return;
            }
            else Console.WriteLine("Operation cannot be completed");//Send to Errors Print
            NewLine(1);
        }

        public static void GameIsReady()
        {   
            EraseConsole(FormsContainer.LargeBox.Length, 25);
            Wait(500);

            for (int i = 0; i < 120; i++)
            {
                _cursorPositionHeight = 27;
                foreach (var line in FormsContainer.GameStartsIn)
                {
                    Console.ForegroundColor = _colors[_rand.Next(0, _colors.Length)];
                    Console.SetCursorPosition(((_screenWidth / 2) - (FormsContainer.GameStartsIn[0].Length / 2)), _cursorPositionHeight++);
                    Console.Write(line);
                    Wait(5);
                }
            }
            EraseConsole(FormsContainer.GameStartsIn.Length, 27);
        }

        /// <summary>
        /// Method which prints all SessionInfo in boxes 
        /// </summary>
        /// <param name="currentSession"></param>
        public static void PrintSessionInfo(GameSession currentSession)
        {
            int height = 27;
            int width = 0;
            string[] arr = new string[3] { " ", " ", " " };
            Player player = currentSession.CurrentPlayer;

            for (int i = 0; i < arr.Length; i++)//Creating array of strings to use it as small boxes filling tool.
            {
                for (int k = 0; k < (FormsContainer.SmallBox[0].Length - 7); k++)
                {
                    arr[i] += " ";
                }
            }

            for (int i = 0; i < 6; i++) //Drawing Small Boxes along the width of the screen
            {
                if (i > 2) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var line in FormsContainer.SmallBox)
                {
                    Console.SetCursorPosition(width, height++);
                    Console.WriteLine(line);
                }
                width += FormsContainer.SmallBox[0].Length;
                height = 27;
            }
            width = 3;
            height = 29;

            for (int i = 0; i < 6; i++)  //Filling Color Inside Each Box
            {
                Console.BackgroundColor = ConsoleColor.Gray;

                foreach (var line in arr)
                {
                    Console.SetCursorPosition(width, height++);
                    Console.WriteLine(line);
                }
                width += FormsContainer.SmallBox[0].Length;
                height = 29;
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(7, 30);
            Console.WriteLine("Name : [{0}]", player.Name);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(39, 30);
            Console.WriteLine("LastName : [{0}]", player.Surname);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(78, 30);
            Console.WriteLine("Age : [{0}]", player.Age);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(108, 30);
            Console.WriteLine("Balance : {0} $", currentSession.CurrentScore);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(137, 30);
            Console.WriteLine("Question Number : {0}/15", currentSession.CurrentQuestion);

            if (currentSession.HelpsRemained == 0) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(171, 30);
            Console.WriteLine("Helps Remained : {0}/1", currentSession.HelpsRemained);
            Console.ResetColor();
        }

        public static void PrintQuestion(GeneralQuestion obj,int helpsRemained)
        {
            int heightQuestioinBox = 35;
            int heightLeftBoxes = 40;
            int heightRightBoxes = 40;
            int widthLeftBox = 40;
            int widthRightBox = 120;
            int tempWidth = 0, tempHeight = 0;
            
            EraseConsole(30, 34);
            if (obj is EasyQuestion)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (obj is MediumQuestion)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }

            foreach (var line in FormsContainer.QuestionBox)
            {
                Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.QuestionBox[0].Length / 2), heightQuestioinBox++); //Putting in the center of the screen
                Console.WriteLine(line);
            }
            if(obj is HardQuestion) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.Black;
                    
            Console.SetCursorPosition((_screenWidth / 2) - (obj.Question.Length / 2), heightQuestioinBox - 2); //Putting in the center of the screen
            Console.WriteLine(obj.Question);
            Console.ResetColor();

            for (int i = 0; i < 4; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
               
                foreach (var line in FormsContainer.AnswerBox)
                {
                    if (i % 2 == 0)
                    {
                        Console.SetCursorPosition(widthLeftBox, heightLeftBoxes++);
                        Console.WriteLine(line);
                        tempWidth = widthLeftBox;
                        tempHeight = heightLeftBoxes;
                    }
                    else
                    {
                        Console.SetCursorPosition(widthRightBox, heightRightBoxes++);
                        Console.WriteLine(line);
                        tempWidth = widthRightBox;
                        tempHeight = heightRightBoxes;
                    }
                }
                Console.SetCursorPosition(tempWidth + 15, tempHeight - 2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{0})  " + obj.Answers[i], i + 1);
            }

            if (helpsRemained != 0)
            {
                tempHeight += 2;
                foreach (var line in FormsContainer.AnswerBox)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition((_screenWidth / 2 + 1) - (line.Length / 2), tempHeight++);
                    Console.WriteLine(line);
                }
                Console.SetCursorPosition((_screenWidth / 2 + 12) - (FormsContainer.AnswerBox[0].Length / 2), tempHeight - 2);
                Console.WriteLine("5)  Give Me A Help");
                Console.ResetColor();
            }
        }

        public static void PrintWinningBill()
        {
            EraseConsole(20, 34);

            for (int i = 0; i < 2; i++)
            {
                _cursorPositionHeight = 35;

                if (i % 2 != 0) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.DarkGreen;
                foreach (var line in FormsContainer.WinningBill)
                {
                    Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.WinningBill[0].Length / 2), _cursorPositionHeight++);
                    Console.WriteLine(line);
                    Wait(35);
                }
            }
            Wait(1200);
        }

        public static void Failed()
        {
            _cursorPositionHeight = 36;

            for (int i = 0; i < 21; i++)
            {
                _cursorPositionHeight = 36;
                foreach (var line in FormsContainer.Fail)
                {
                    if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.Fail[0].Length / 2), _cursorPositionHeight++);
                    Console.WriteLine(line);
                    Wait(10);
                }
                Wait(35);
            }
        }

        public static void AskToContinue(GeneralQuestion currentQuestion)
        {
            EraseConsole(20, 34);
            Failed();
            Wait(850);
            EraseConsole(20, 34);

            _cursorPositionHeight = 34;

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var line in FormsContainer.FancyBoxBottom)
            {
                Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.FancyBoxBottom[0].Length / 2), _cursorPositionHeight++);
                Console.WriteLine(line);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.FancyBoxBottom[0].Length / 2) + 34, 35);
            Console.WriteLine("To Continue The Game For 20000$ Press on 'Y'");
            Console.SetCursorPosition((_screenWidth / 2) - (FormsContainer.FancyBoxBottom[0].Length / 2) + 35, 37);
            Console.WriteLine("To Leave The Game With 50000$ Press on 'N'");
        }

        public static void YouAre_Millionaire()
        {
            Wait(1000);
            Console.Clear();
                      
            for (int i = 0; i < 50; i++)
            {
                _cursorPositionHeight = _screenHeight / 2 - FormsContainer.YouAreWinner.Length;
                foreach (var line in FormsContainer.YouAreWinner)
                {
                    Console.ForegroundColor = _colors[_rand.Next(0, _colors.Length)];
                    Console.SetCursorPosition(_screenWidth / 2 - FormsContainer.YouAreWinner[0].Length / 2, _cursorPositionHeight++);
                    Console.WriteLine(line);
                    Wait(10);
                }
            }

            Wait(100);
            for (int i = 0; i < 60; i++)
            {
                _cursorPositionHeight = _rand.Next(0, _screenHeight - 28);
                _cursorPositionWidth = _rand.Next(0, _screenWidth - FormsContainer.WinningBill[0].Length);

                foreach (var line in FormsContainer.WinningBill)
                {
                    Console.SetCursorPosition(_cursorPositionWidth, _cursorPositionHeight++);
                    if (i % 2 != 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(line);
                }
                Wait(150);
            }            
        }

        public static void PrintGameOver()
        {
            Wait(200);
            Console.Clear();           
           
            for (int i = 0; i < 40; i++)
            {
                _cursorPositionHeight = _rand.Next(0, _screenHeight - 25);
                _cursorPositionWidth  = _rand.Next(0, _screenWidth - FormsContainer.GameOverText[3].Length);

                foreach (var line in FormsContainer.GameOverText)
                {
                        if (i % 2 != 0) Console.ForegroundColor = ConsoleColor.DarkRed;
                        else Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(_cursorPositionWidth, _cursorPositionHeight++);
                        Console.WriteLine(line);
                }                  
                    Wait(200);
             }

            Wait(1000);
            Console.Clear();
            _cursorPositionHeight = 5;

            foreach (var line in FormsContainer.GameOver)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(_screenWidth / 2 - FormsContainer.GameOver[8].Length / 2 - 12, _cursorPositionHeight++);
                Console.WriteLine(line);
            }

            _cursorPositionHeight += 1;
            foreach (var line in FormsContainer.GameOverText)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(_screenWidth / 2 - FormsContainer.GameOverText[0].Length / 2, _cursorPositionHeight++);
                Console.WriteLine(line);
            }
        }

        private static void NewLine(int numOfLines)
        {
            for (int i = 0; i <= numOfLines; i++)
            {
                Console.WriteLine();
            }
        }

        private static void Blink(string[] arr, int iteration = 20, short blinkTimeOut = 100)
        {
            int index = 0;
            for (int i = 0; i < iteration; i++)
            {
                Console.ForegroundColor = _colors[index++];
                if (index == _colors.Length) index = 0;

                foreach (var line in arr)
                {
                    Console.WriteLine(line);
                }
                Wait(blinkTimeOut);
                if (i == iteration - 1) break;
                Console.Clear();
            }
        }

        private static void EraseConsole(int numOfLines, int position_y, int position_x = 0)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            string str = "";

            if (position_x == 0)
            {
                for (int i = 0; i < _screenWidth; i++)
                {
                    str += "!";
                }
            }
            else
            {
                for (int i = 0; i < (_screenWidth - position_x); i++)
                {
                    str += "!";
                }
            }

            for (int i = 0; i <= numOfLines; i++)
            {
                Console.SetCursorPosition(position_x, position_y++);
                Console.WriteLine(str);
            }
            Console.ResetColor();
        }

        public static void Wait(short timeOut)
        {
            Thread.Sleep(timeOut);
        }

        public static void PrintAgeException(string message)
        {
            string str = "You Will Be Kicked Out of The Game.";

            Console.Clear();
            Console.SetCursorPosition(_screenWidth / 2 - message.Length / 2, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(message);
            Wait(2000);

            Console.SetCursorPosition(_screenWidth / 2 - str.Length / 2, 6);
            Console.WriteLine(str);
            Wait(2000);
            Console.ResetColor();
        }
    } 
}
