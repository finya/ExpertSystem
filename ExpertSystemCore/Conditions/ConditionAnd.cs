using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    class ConditionAnd:AbstractCondition
    {
        public List<Condition> conditions = new List<Condition>();

        public ConditionAnd(List<Condition> conditions, string result)
        {
            this.conditions = conditions;
            this.result = result;
        }

        public override bool isTruth()
        {
            return true;
        }
    }
}
