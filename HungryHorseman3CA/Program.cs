using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AICoreSOLID;

namespace HungryHorseman3CA
{
    class Program
    {
        static void PrintState(HungryHorseman3 state)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.X == i && state.Y == j)
                        Console.Write("H");
                    else Console.Write("_");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            HungryHorseman3 state = new HungryHorseman3();
            PrintState(state);
            do
            {
                List<Operator> operators = state.GetApplicableOperators();
                Operator selected = operators[rnd.Next(operators.Count)];
                state = (HungryHorseman3)selected.Apply(state);
                Console.ReadLine();
                PrintState(state);
            } while (!state.IsGoalState());

            Console.ReadLine();
        }
    }
}
