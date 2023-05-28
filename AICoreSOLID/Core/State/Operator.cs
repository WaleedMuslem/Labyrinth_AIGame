using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICoreSOLID
{
    public abstract class Operator
    {
        public bool IsApplicable(State state)
        {
            if (PreCondiction(state))
            {
                State newState = Apply(state/*.Clone()*/);
                return newState.IsState();
            }
            return false;
        }

        protected abstract bool PreCondiction(State state);
        public abstract State Apply(State state);
    }
}
