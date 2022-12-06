using Accessibility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku_0._1
{
    internal class Generate
    {
        Solver solver;
        Random random;
        public int[,] GeneratedBoard { get; set; }
        public int Dif { get; set; }

        public Generate(int dif)
        {
            Dif = dif;
            GeneratedBoard = new int[Dif, Dif];
        }
        public void genRow()
        {

        }
        public void genCol()
        {

        }
        public bool CheckBox()
        {
            return false;
        }
        public bool solve()
        {
            return true;
        }
        public void remove()
        {

        }        
    }
}
