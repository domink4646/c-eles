using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }
        static void Task1()
        {

            string Move = Input<string>("Enter the knight's position (e.g., 'E4'): ").ToLowerInvariant();

            int row = int.Parse(Move.Substring(1, 1));
            int columnIndex = Move[0] - 'a';

            int[,] board = new int[8, 8];

            int knightPosition = board[row - 1, columnIndex];

            string[,] legalMovesBoard = new string[8, 8];

            int counter = 0;

            int[,] moves = new int[,]
            {
                { -2, -1 }, { -2, 1 }, { -1, -2 }, { -1, 2 },
                { 1, -2 }, { 1, 2 }, { 2, -1 }, { 2, 1 }
            };

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int newRow = row - 1 + moves[i, 0];
                int newCol = columnIndex + moves[i, 1];
                if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
                {
                    legalMovesBoard[newRow, newCol] = "x";
                    counter++;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == row - 1 && j == columnIndex)
                    {
                        Console.Write("K ");
                    }
                    else if (legalMovesBoard[i, j] == "x")
                    {
                        Console.Write("x ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"The knight can move to {counter} different positions.");
        }
        static T Input<T>(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }
    }
}
