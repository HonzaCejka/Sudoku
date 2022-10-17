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
                switch (i)
                {   case 0:
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
                        break;
                    case 1:
                        for (int x = 0; x < 9;x++)
                        {                           
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i-1,x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 2:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString())|| y == int.Parse(board.GetValue(i - 2, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 3:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString())|| y == int.Parse(board.GetValue(i - 3, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 4:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 5:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()) || y == int.Parse(board.GetValue(i - 5, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 6:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()) || y == int.Parse(board.GetValue(i - 5, x).ToString())|| y == int.Parse(board.GetValue(i - 6, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 7:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()) || y == int.Parse(board.GetValue(i - 5, x).ToString()) || y == int.Parse(board.GetValue(i - 6, x).ToString()) || y == int.Parse(board.GetValue(i - 7, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 8:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()) || y == int.Parse(board.GetValue(i - 5, x).ToString()) || y == int.Parse(board.GetValue(i - 6, x).ToString()) || y == int.Parse(board.GetValue(i - 7, x).ToString()) || y == int.Parse(board.GetValue(i - 8, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    case 9:
                        for (int x = 0; x < 9; x++)
                        {
                            int y = random.Next(1, 10);
                            if (y == int.Parse(board.GetValue(i - 1, x).ToString()) || y == int.Parse(board.GetValue(i - 2, x).ToString()) || y == int.Parse(board.GetValue(i - 3, x).ToString()) || y == int.Parse(board.GetValue(i - 4, x).ToString()) || y == int.Parse(board.GetValue(i - 5, x).ToString()) || y == int.Parse(board.GetValue(i - 6, x).ToString()) || y == int.Parse(board.GetValue(i - 7, x).ToString()) || y == int.Parse(board.GetValue(i - 8, x).ToString()) || y == int.Parse(board.GetValue(i - 9, x).ToString()))
                            {
                                x--;
                            }
                            else if (Line.Contains(y))
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
                        break;
                    default:
                        break;
                }
                
                
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
