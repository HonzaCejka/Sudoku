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
        Random random = new Random();
        List<int> Line = new List<int>();           
        public int[,] board = new int[9, 9];
        public string result;
        public int length;
        public Generate()
        {
            result = "";        
        }
        public void SetLength(int Length)
        {           
            length = Length;
            for (int i = 1; i < Length+1; i++)
            {
                Line.Add(i);
            }
            
        }
        public void GenBoard1()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {

                    int y = random.Next(1, 10);
                    if (Line.Contains(y))
                    {
                        board[i, x] = y;
                        Line.Remove(y);

                    }
                    else
                    {
                        x--;
                    }
                }
                SetLength(length);

            }
        }
        public void ShowBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    result += board.GetValue(x, i).ToString();
                }
            }
        }
    }
}
