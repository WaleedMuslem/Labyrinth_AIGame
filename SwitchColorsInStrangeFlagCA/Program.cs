using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AICore;

namespace SwitchColorsInStrangeFlagCA
{
    class Program
    {
        static char P = Encoding.GetEncoding(437).GetChars(new byte[] { 219 })[0];

        static void PrintState(SwitchColorsInStrangeFlagState state)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < state.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < state.Cells.GetLength(1); j++)
                {
                    switch (state.Cells[i, j])
                    {
                        case 'r': Console.ForegroundColor = ConsoleColor.Red; break;
                        case 'g': Console.ForegroundColor = ConsoleColor.Green; break;
                        case 'w': Console.ForegroundColor = ConsoleColor.White; break;
                        case 'x': Console.ForegroundColor = ConsoleColor.Black; break;
                        default: break;
                    }
                    Console.Write(P);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();           
            SwitchColorsInStrangeFlagState state = new SwitchColorsInStrangeFlagState();
            PrintState(state);
            do
            {
                int i = rnd.Next(1, 6);
                int j = rnd.Next(1, 4);
                Direction direction = (Direction)rnd.Next(4);
                if (state.ApplyOperator(i, j, direction))
                {                    
                    PrintState(state);
                }
            } while (!state.IsGoalState());
            PrintState(state);

            Console.ReadLine();
        }
    }
}
