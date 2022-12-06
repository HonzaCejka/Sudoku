using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_0._1
{
    internal class money
    {
        public int Money { get; set; }
        public money(int money)
        {
            Money = money;            
        }
        public void Continue()
        {
            Money -= 10;
        }
        public void win(int time)
        {
            if (time <=600)
            {
                Money += 100;
            }
            else if (time<=1800)
            {
                Money += 10;
            }
            else
            {
                Money -= 5;             
            }
        }
    }
}
