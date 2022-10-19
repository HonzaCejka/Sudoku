﻿using Accessibility;
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
        public int length;
        public string result;
        Random random = new Random();
        List<int> Line = new List<int>();
        public int[,] board;
        
        
        public Generate()
        {
            board = new int[length,length];
            result = "";        
        }
        public void GenLength(int Length)
        {
            for (int i = 1; i < Length + 1; i++)
            {
                Line.Add(i);
            }
        }
        public void SetLength(int Length)
        {           
            length = Length;
            GenLength(length);
            board = new int[length,length];            
        }

        public void GenBoard1()
        {
            for (int i = 0; i < length; i++)
            {
                for (int x = 0; x < length; x++)
                {

                    int y = random.Next(1, length + 1);                   
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
                GenLength(length);

            }
        }
        public void ShowBoard()
        {
            for (int i = 0; i < length; i++)
            {
                for (int x = 0; x < length; x++)
                {
                    result += board.GetValue(i,x).ToString();
                }
            }
        }
    }
}