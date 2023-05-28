using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class BacktrackLabyrinthBall : GraphSearchLabyrinthBall
    {
        private int maxDepth;
        private bool isMemorable;
        public BacktrackLabyrinthBall(int maxDepth, bool isMemorable)
        {
            this.maxDepth = maxDepth;
            this.isMemorable = isMemorable;
        }

        public BacktrackLabyrinthBall() : this(0, false) { }
        public BacktrackLabyrinthBall(int maxDepth) : this(maxDepth, false) { }
        public BacktrackLabyrinthBall(bool isMemorable) : this(0, isMemorable) { }
        public override LabyrinthBallNode Search()
        {
            return Search(StartNode);
        }

        private LabyrinthBallNode Search(LabyrinthBallNode actualNode)
        {
            int actualDepth = actualNode.Depth;

            //Check if we reached the maximum depth
            if (maxDepth != 0 && actualDepth >= maxDepth)
                return null;

            //Check if we already checked the same node
            LabyrinthBallNode actualParent = null;
            if (isMemorable)
                actualParent = actualNode.Parent;
            while (actualParent != null)
            {
                if (actualNode.Equals(actualParent))
                    return null;
                actualParent = actualParent.Parent;
            }

            //Check if the actual node is a terminal node
            if (actualNode.IsTerminalNode)
                return actualNode;

            //Select a new node


            for (int action = 0; action < 4; action++)
            {
                LabyrinthBallNode newNode = new LabyrinthBallNode(actualNode);
                if (newNode.State.ApplyOperator((Direction)action))
                {
                    LabyrinthBallNode terminalNode = Search(newNode);
                    if (terminalNode != null)
                        return terminalNode;
                }
            }


            return null; //There is no solution of the problem
        }
    }
}
