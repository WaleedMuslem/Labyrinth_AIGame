using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICoreSOLID
{
    public abstract class State//: ICloneable
    {
        //Operator stateOperator;
        //public State(Operator stateOperator)
        //{
        //    this.stateOperator = stateOperator;
        //}

        public abstract bool IsState();
        public abstract bool IsGoalState();
        protected abstract List<Operator> GetOperators();
        public List<Operator> GetApplicableOperators()
        {
            List<Operator> allOperators = GetOperators();
            List<Operator> applicableOperators = allOperators.AsParallel()
                                                             .Where(o => o.IsApplicable(this))
                                                             .ToList();
            return applicableOperators;
        }
    }
}
