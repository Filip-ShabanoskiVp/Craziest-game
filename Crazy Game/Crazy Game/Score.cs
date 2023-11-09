using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Game
{
   public class Score
    {
        private int score;
        public Score()
        {
            score = 0;
        }
        public void UpdateScore()
        {
            score = score + 1;
        }
        public int getScore()
        {
            return score;
        }
    }
}
