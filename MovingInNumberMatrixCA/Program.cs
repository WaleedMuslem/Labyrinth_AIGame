using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AICore;

namespace MovingInNumberMatrixCA
{
    class Program
    {
        static void PrintState(MovingInNumberMatrixState state)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < MovingInNumberMatrixState.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < MovingInNumberMatrixState.matrix.GetLength(1); j++)
                {
                    if (i == state.X && j == state.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }                    
                    Console.Write(MovingInNumberMatrixState.matrix[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            MovingInNumberMatrixState state = new MovingInNumberMatrixState();
            PrintState(state);
            do
            {                
                Direction8 direction = (Direction8)rnd.Next(8);
                if (state.ApplyOperator(direction))
                {
                    PrintState(state);
                    System.Threading.Thread.Sleep(100);
                }
            } while (!state.IsGoalState());
            PrintState(state);
            Console.ReadLine();
        }
    }
}
