using System;
using System.Collections.Generic;
using System.Linq;

namespace Queens
{
    class Program
    {
        public static List<QueenData> putQueens = new List<QueenData>();
        public static int countQueens = 0;

        static void Main(string[] args)
        {
            int queensCount = 10;
            var board = new bool[queensCount, queensCount];

            PutQueen(board);
            Console.WriteLine("Count of queens is " + countQueens);
        }

        private static void PutQueen(bool[,] board, int row = 0)
        {
            if(row == board.GetLength(0))
            {
                PrintBoard(board);
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    board[row, col] = true;
                    var newQueen = new QueenData()
                    {
                        Row = row,
                        Col = col,
                        LeftDiadonal = row-col,
                        RigthDiadonal = row + col,
                    };

                    putQueens.Add(newQueen);
                    PutQueen(board, row + 1);

                    board[row, col] = false;
                    putQueens.Remove(newQueen);
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
            => !(putQueens.Any(q => q.Row == row) ||
                putQueens.Any(q => q.Col == col) ||
                putQueens.Any(q => q.LeftDiadonal == row - col) ||
                putQueens.Any(q => q.RigthDiadonal == row + col));

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if(board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            countQueens++;
        }
    }
}
