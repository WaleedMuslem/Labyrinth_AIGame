using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public abstract class GraphSearchLabyrinthBall
    {
        LabyrinthBallNode startNode;

        public GraphSearchLabyrinthBall()
        {
            this.startNode = new LabyrinthBallNode();
        }

        public LabyrinthBallNode StartNode { get { return this.startNode; } }

        public abstract LabyrinthBallNode Search();

        public Stack<LabyrinthBallNode> GetSolution(LabyrinthBallNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return null;
            }

            Stack<LabyrinthBallNode> solution = new Stack<LabyrinthBallNode>();
            LabyrinthBallNode node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            return solution;
        }

    }
}
