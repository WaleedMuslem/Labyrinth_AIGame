using AICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceColoredDisksCA
{
    class Program
    {
        static char P = Encoding.GetEncoding(437).GetChars(new byte[] { 178 })[0];
        static void PrintState(ReplaceColoredDisksState state)
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    switch (state.Disks[i, j])
                    {
                        case 'r': Console.ForegroundColor = ConsoleColor.Red; break;
                        case 'b': Console.ForegroundColor = ConsoleColor.Blue; break;
                        case 'w': Console.ForegroundColor = ConsoleColor.White; break;
                        default: break;
                    }
                    Console.Write(P);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            ReplaceColoredDisksState state = new ReplaceColoredDisksState();
            PrintState(state);

            Console.ReadLine();
        }
    }
}
