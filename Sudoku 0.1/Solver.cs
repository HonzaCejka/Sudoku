using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku_0._1
{
    internal class Solver
    {
        public int[,] FinalBoard { get; set; }
        public int Length { get; set; }
        public int[,] board { get; set; }
        public string[,] Cont { get; set; }
        public string Con { get; set; }
        public bool done { get; set; }
        public Solver(int length, string con)
        {
            Length = length;                        
            Con = con;
            board = new int[9, 9];
            Cont = new string[9, 9];

            convert();           
            if (solveBoard(board))
            {                
                done = true;
            }
            else
            {
                MessageBox.Show("Nejde");
                done=false;
            }
        }
        public void build()
        {           
            Con = Con.ToLower();        
            Con = Con.Replace(";", "");
            String[] Polestr = new string[81];
            for (int i = 0; i < 81; i++)
            {
                string mezipoc;
                mezipoc = Con.Substring(i, 1);
                Polestr[i] = mezipoc;
            }

            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    Cont[x, y] = Polestr[(int)(x * Length + y)];
                }
            }
            return;
        }        
        public void convert()
        {
            build();
            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    board[x, y] = int.Parse(Cont[x,y]);
                }
            }
        }

        private bool IsInRow(int[,] board,int number, int row)
        {
            for (int i = 0; i < Length; i++)
            {
                if (board[row,i]==number)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsInCol(int[,] board, int number, int col)
        {
            for (int i = 0; i < Length; i++)
            {
                if (board[i,col] == number)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsInBox(int[,] board, int number, int col,int row)
        {
            int localBoxRow = row - row % 3;
            int localBoxCol = col - col % 3;

            for (int i = localBoxRow; i < localBoxRow + 3; i++)
            {
                for (int j = localBoxCol; j < localBoxCol + 3; j++)
                {
                    if (board[j,i] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool isValid(int[,] board, int number, int col, int row)
        {
            return !IsInRow(board, number, row) &&
                !IsInCol(board, number, col) &&
                !IsInBox(board,number,row,col);
        }
        public bool solveBoard(int[,] board)
        {
            for (int row = 0; row < Length; row++)
            {
                for (int col = 0; col < Length; col++)
                {
                    if (board[row,col] == 0)
                    {
                        for (int numToTry = 1; numToTry <= Length; numToTry++)
                        {
                            if (isValid(board,numToTry,col,row))
                            {
                                board[row, col] = numToTry;

                                if (solveBoard(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[row, col] = 0;
                                }
                                
                            }
                        }
                        return false;
                    }
                }
            }
            FinalBoard = board;
            return true;
        }        
    }
}
 