using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    class ConditionAnd : AbstractCondition
    {
        public List<AbstractCondition> conditions = new List<AbstractCondition>();
        public List<Boolean> boolList = new List<bool>();

        public ConditionAnd(List<AbstractCondition> conditions, string result)
        {
            this.conditions = conditions;
            this.result = result;
        }

        public override bool isTruth()
        {
            foreach (AbstractCondition condition in conditions)
            {
                boolList.Add(condition.isTruth());
            }
            return boolList.Where(p => p == true).ToList().Count == boolList.Count;
        }
    }
}
