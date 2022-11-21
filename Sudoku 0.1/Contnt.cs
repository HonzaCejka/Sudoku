using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sudoku_0._1
{
    internal class Contnt
    {
        public string con { get; set; }
        public String[,] Contall; 
        

        public Contnt()
        {
            con = "2;4;0;0;0;6;0;5;01;0;0;5;0;0;0;0;60;0;0;0;0;0;7;1;40;0;0;0;6;7;1;3;00;1;0;0;5;0;0;6;00;3;5;2;1;0;0;0;09;8;2;0;0;0;0;0;05;0;0;0;0;1;0;0;80;6;0;8;0;0;0;2;7";
            Contall = new string[9, 9];
        }

        public void build()
        {
            con = con.ToLower();
            con = con.Replace("0", " ");
            con = con.Replace(";", "");
            String[] Polestr = new string[81];
            for (int i = 0; i < 9*9; i++)
            {
                string mezipoc;
                mezipoc = con.Substring(i, 1);
                Polestr[i] = mezipoc;
            }
            
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Contall[x, y] = Polestr[x * 9 + y];
                }
            }
            return;
        }

    } 
            
}
