using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{

    public class TrialAndErrorLabyrinthBall : GraphSearchLabyrinthBall
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


        private static Random rnd;
        private int maxDepth;
        static TrialAndErrorLabyrinthBall()
        {
            rnd = new Random();
        }

        public TrialAndErrorLabyrinthBall(int maxDepth = Int32.MaxValue)
        {
            this.maxDepth = maxDepth;
        }

        public override LabyrinthBallNode Search()
        {
            return Search(StartNode);
        }

        private LabyrinthBallNode Search(LabyrinthBallNode actualNode)
        {
            int actualDepth = actualNode.Depth;

            if (maxDepth != 0 && actualDepth >= maxDepth)
                return null;

            if (actualNode.IsTerminalNode)
                return actualNode;

            do
            {
                Direction direction = (Direction)rnd.Next(0, Enum.GetNames(typeof(Direction)).Length);

                LabyrinthBallNode newNode = new LabyrinthBallNode(actualNode);
                if (newNode.State.ApplyOperator(direction))
                {
                    //PrintState(newNode.State);
                    System.Threading.Thread.Sleep(1000);
                    LabyrinthBallNode terminalNode = Search(newNode);
                    if (terminalNode != null)
                        return terminalNode;
                }
            } while (!actualNode.IsTerminalNode);

            return null;
        }
    }
}
