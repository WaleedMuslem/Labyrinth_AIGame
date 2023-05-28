using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICoreSOLID
{
    public class HungryHorseman3 : State
    {
        private class Moving : Operator
        {
            private int dx, dy;
            public Moving(int dx, int dy)
            {
                this.dx = dx;
                this.dy = dy;
            }

            protected override bool PreCondiction(State state)
            {
                HungryHorseman3 actualState = (HungryHorseman3)state;
                //if (Math.Abs(dx) + Math.Abs(dy) != 3) return false;
                if (actualState.X + dx < 0 || actualState.X + dx > 2) return false;
                if (actualState.Y + dy < 0 || actualState.Y + dy > 2) return false;
                return true;
            }
            public override State Apply(State state)
            {
                HungryHorseman3 previousState = (HungryHorseman3)state;
                previousState.x += dx;
                previousState.y += dy;
                return new HungryHorseman3(previousState.x, previousState.y);
            }
        }

        private int x, y;
        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public HungryHorseman3()
        {
            this.x = 0;
            this.y = 0;
        }
        private HungryHorseman3(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool IsState()
        {
            return 0 <= this.x && this.x <= 2 &&
                   0 <= this.y && this.y <= 2;
        }

        public override bool IsGoalState()
        {
            return this.x == 2 && this.y == 2;
        }

        protected override List<Operator> GetOperators()
        {
            return new List<Operator>()
            {
                new Moving(2, 1),
                new Moving(2, -1),
                new Moving(-2, 1),
                new Moving(-2, -1),
                new Moving(1, 2),
                new Moving(1, -2),
                new Moving(-1, 2),
                new Moving(-1, -2)
            };
        }
    }
}
