using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_0._1
{
    internal class Checko
    {
        public String[,] PoleCheker { get; set; }
        public String[,] Pole { get; set; }
        public int Dif = 0;
        public int MyProperty { get; set; }

        public Checko(int dif,string[,] pole)
        {
            PoleCheker = new string[dif,dif];
            Dif = dif;
            Pole = pole;
        }
        public void GenCheck()
        {
            for (int y = 0; y < Dif; y++)
            {
                for (int x = 0; x < Dif; x++)
                {
                    PoleCheker[y,x] = Pole[y,x];
                }
            }
        }
        public void check()
        {

        }
    }
}
