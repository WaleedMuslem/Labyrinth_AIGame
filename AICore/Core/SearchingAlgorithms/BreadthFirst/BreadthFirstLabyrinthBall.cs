using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class BreadthFirstLabyrinthBall : GraphSearchLabyrinthBall
    {
        Queue<LabyrinthBallNode> openNodes;
        List<LabyrinthBallNode> closedNodes;
        bool circleDetection;

        public BreadthFirstLabyrinthBall(bool circleDetection)
        {
            this.openNodes = new Queue<LabyrinthBallNode>();
            this.openNodes.Enqueue(new LabyrinthBallNode());
            this.closedNodes = new List<LabyrinthBallNode>();
            this.circleDetection = circleDetection;
        }
        public BreadthFirstLabyrinthBall() : this(true) { }

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
                LabyrinthBallNode actual = openNodes.Dequeue();
                List<LabyrinthBallNode> children = actual.GetAllChildren();
                foreach (LabyrinthBallNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                        openNodes.Enqueue(child);
                }
                closedNodes.Add(actual);
            }
            return null;
        }
        private LabyrinthBallNode SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                LabyrinthBallNode actual = openNodes.Dequeue();
                List<LabyrinthBallNode> children = actual.GetAllChildren();
                foreach (LabyrinthBallNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;
                    openNodes.Enqueue(child);
                }
            }
            return null;
        }
    }
}
