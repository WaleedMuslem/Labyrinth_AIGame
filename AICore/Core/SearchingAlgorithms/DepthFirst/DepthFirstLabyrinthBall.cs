using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class DepthFirstLabyrinthBall : GraphSearchLabyrinthBall
    {
        Stack<LabyrinthBallNode> openNodes;
        List<LabyrinthBallNode> closedNodes;
        bool circleDetection;

        public DepthFirstLabyrinthBall(bool circleDetection)
        {
            this.openNodes = new Stack<LabyrinthBallNode>();
            this.openNodes.Push(new LabyrinthBallNode());
            this.closedNodes = new List<LabyrinthBallNode>();
            this.circleDetection = circleDetection;
        }
        public DepthFirstLabyrinthBall() : this(true) { }

        public override LabyrinthBallNode Search()
        {
            if (this.circleDetection)
                return SearchTerminalNodeWithCircleDetection();
            return SearchTerminalNodeWithoutCircleDetection();
        }

        private LabyrinthBallNode SearchTerminalNodeWithCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                LabyrinthBallNode actual = openNodes.Pop();
                List<LabyrinthBallNode> children = actual.GetAllChildren();
                foreach (LabyrinthBallNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                        openNodes.Push(child);
                }
                closedNodes.Add(actual);
            }
            return null;
        }
        private LabyrinthBallNode SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                LabyrinthBallNode actual = openNodes.Pop();
                List<LabyrinthBallNode> children = actual.GetAllChildren();
                foreach (LabyrinthBallNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;
                    openNodes.Push(child);
                }
            }
            return null;
        }
    }
}
