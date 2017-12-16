using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class ErrorsCheckig
    {
        public static int CheckingAgeInput()
        {
            int age = 0;

            try
            {
                age = int.Parse(Console.ReadLine());
                if (age < 18 || age > 120) throw new AgeException();
                return age;
            }
            catch (AgeException ex)
            {
                if (age < 18) PrintingEngine.PrintAgeException(ex.TooYoung);
                else PrintingEngine.PrintAgeException(ex.TooOld);
                GameManager.AllowedToEnterTheGame = false;
            }
            catch (Exception ex)
            {
                PrintingEngine.PrintAgeException("Age input must consist only from integers !!!");
                GameManager.AllowedToEnterTheGame = false;
            }
            return age;
        }
    }
}
