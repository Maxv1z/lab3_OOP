using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
        public interface PlayerType
    {
        int ChangedRating(bool isWin);
    } 

    class Warrior : PlayerType
    {
        public int ChangedRating(bool winORlose)
        {
            return winORlose ? 0 : 0;
        }
    }

    class Assassin : PlayerType
    {
        public int ChangedRating(bool winORlose)
        {
            return winORlose ? 0 : -40; 
        }
    }

    class HollowKnight : PlayerType
    {
        private int WinsInRow = 0;

        public int ChangedRating(bool winORlose)
        {
            if (winORlose)
            {
                WinsInRow++;
                return WinsInRow * 20; 
            }
            else
            {
                WinsInRow = 0; 
                return -50;
            }
        }
    }
}
