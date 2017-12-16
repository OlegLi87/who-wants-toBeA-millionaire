using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quest;

namespace GameEngine
{
    public class AnswersShuffle : IComparer
    {
        public static Random rand = new Random();

        public int Compare(object x, object y)
        {
            return rand.Next(-1,1);
        }

        public void SfuffleQuestion<T>(List<T> list) where T:GeneralQuestion
        {
            list.Sort();
        }
    }
}
