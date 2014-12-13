using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public class ConditionOr : AbstractCondition
    {
        private List<AbstractCondition> conditions = new List<AbstractCondition>();

        public ConditionOr(List<AbstractCondition> conditions, string result)
        {
            this.conditions = conditions;
            this.result = result;
        }

        public override bool isTruth(Hypothesis hyp)
        {
            List<Boolean> boolList = new List<bool>();
            foreach (AbstractCondition condition in conditions)
            {
                boolList.Add(condition.isTruth(hyp));
            }
            return boolList.Where(p => p == true).ToList().Count > 0;
        }
    }
}
