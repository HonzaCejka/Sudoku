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
            con = ";2;6;4;;;;;5;;;;;;9;;3;9;4;;7;;;;62;;;;1;;;6;8;;9;;;;2;;3;6;;;3;;;;97;;;;9;;6;3;8;;2;;;;;;6;;;;;3;1;9;";  
            Contall = new string[9, 9];
        }

        public void build()
        {
            con = con.ToLower();
            con = con.Replace(";", " ");
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
