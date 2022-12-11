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
        public double Dif { get; set; }
        public string con { get; set; }
        public string[,] Contall { get; internal set; }        
        double DoubleDifNaDruhou;
        int DifNaDruhou;

        GetTxt gen = new GetTxt();
        public Contnt(int dif)
        {
            
            GetLine();
            Contall = new string[dif, dif];            
            Dif = dif;
            DoubleDifNaDruhou = Math.Pow(dif, 2);            
        }        
        public void GetLine()
        {
            gen.GetRandString();
            con = gen.line;
        }
        public void build()
        {
            DifNaDruhou = int.Parse(DoubleDifNaDruhou.ToString());
            con = con.ToLower();
            con = con.Replace("0", " ");
            con = con.Replace(";", "");
            String[] Polestr = new string[DifNaDruhou];
            for (int i = 0; i < DifNaDruhou; i++)
            {
                string mezipoc;
                mezipoc = con.Substring(i, 1);
                Polestr[i] = mezipoc;
            }
            
            for (int x = 0; x < Dif; x++)
            {
                for (int y = 0; y < Dif; y++)
                {
                    Contall[x, y] = Polestr[(int)(x * Dif + y)];
                }
            }                        
            return;
        }

    } 
            
}
