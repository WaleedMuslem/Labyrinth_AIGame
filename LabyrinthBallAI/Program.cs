using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AICore;

namespace LabyrinthBall
{
    class Program
    {
        static void PrintState(LabyrinthBallState state)
        {
            int numRows = LabyrinthBallState.labyrinth.GetLength(0);
            int numCols = LabyrinthBallState.labyrinth.GetLength(1);


            // Iterate through each cell in the labyrinth
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // Check if the current cell represents the ball's position
                    if (row == state.Row && col == state.Col)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('B'); // Display the ball as 'B'
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(LabyrinthBallState.labyrinth[row, col]); // Display other cells as-is
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            LabyrinthBallNode startNode = new LabyrinthBallNode();
            BacktrackLabyrinthBall backtrack = new BacktrackLabyrinthBall(19, true);
            DepthFirstLabyrinthBall depthFirst = new DepthFirstLabyrinthBall();
            BreadthFirstLabyrinthBall breadthFirst = new BreadthFirstLabyrinthBall();
            TrialAndErrorLabyrinthBall trialAndError = new TrialAndErrorLabyrinthBall(1000);
            LabyrinthBallNode terminalNode = backtrack.Search();

            //backtrack.PrintSolution(terminalNode);
            int steps = 0;
            foreach (var node in backtrack.GetSolution(terminalNode))
            {
                PrintState(node.State);
                steps++;
                Console.WriteLine("\n\nSteps: {0}", steps);
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("\nThe process is finished in {0} steps!", steps);

            Console.ReadLine();
        }
    }
}
