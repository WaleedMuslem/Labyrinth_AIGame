using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AICore;

namespace HungryHorsemanNCA
{
    class Program
    {
        static void PrintState(HungryHursemanN state)
        {
            for (int i = 0; i < state.N; i++)
            {
                for (int j = 0; j < state.N; j++)
                {
                    if (state.X == i && state.Y == j)
                        Console.Write("H");
                    else Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            HungryHursemanN hh = new HungryHursemanN(5);
            PrintState(hh);
            do
            {                
                int operatorIndex = rnd.Next(hh.GetNrOfOperators());
                if (hh.ProxyOperator(operatorIndex))
                {
                    Console.ReadLine();
                    Console.SetCursorPosition(0, 0);
                    PrintState(hh);
                }
            } while (!hh.IsGoalState());

            Console.ReadLine();
        }
    }
}
