using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class AgeException : Exception
    {
        public string TooYoung
        {
            get
            {
                return string.Format("You are not allowed to play since you are under 18 !!!");
            }
        }

        public string TooOld
        {
            get
            {
                return string.Format("You are kiddding no way people live so long !!!");
            }
        }

    }
}
