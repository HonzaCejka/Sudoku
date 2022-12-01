using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_0._1
{
    internal class GetTxt
    {
        string[] lines = System.IO.File.ReadAllLines(@"Save.txt");
        public string line { get; set; }
        int length;
        int index;
        Random random = new Random();
        public GetTxt()
        {
            length = lines.Length;            
        }
        public void GetRandString()
        {
            index = random.Next(0,length);
            if (lines[index] == " ")
            {
                return;
            }
            else
            {
                line = lines[index];
            }            
        }
    }
}
