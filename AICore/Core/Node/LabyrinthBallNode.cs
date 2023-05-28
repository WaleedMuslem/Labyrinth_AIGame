using AICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICore
{
    public class LabyrinthBallNode
    {
        LabyrinthBallState state;
        int depth;
        LabyrinthBallNode parent;


        public LabyrinthBallNode()
        {
            this.state = new LabyrinthBallState();
            this.depth = 0;
            this.parent = null;
        }
        public LabyrinthBallNode(LabyrinthBallNode parent)
        {
            this.state = (LabyrinthBallState)parent.state.Clone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public LabyrinthBallNode Parent { get { return parent; } }
        public LabyrinthBallState State { get { return this.state; } }
        public int Depth { get { return depth; } }
        public bool IsTerminalNode { get { return state.IsGoalState(); } }


        public List<LabyrinthBallNode> GetAllChildren()
        {
            List<LabyrinthBallNode> children = new List<LabyrinthBallNode>();


            for (int action = 0; action < 4; action++)
            {
                Direction direction = (Direction)action;
                LabyrinthBallNode childNode = new LabyrinthBallNode(this);
                if (childNode.state.ApplyOperator(direction))
                    children.Add(childNode);
            }

            return children;
        }

        public override bool Equals(object obj)
        {
            LabyrinthBallNode other = (LabyrinthBallNode)obj;
            return this.state.Equals(other.state);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
