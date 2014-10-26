using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    class ConditionOr:AbstractCondition
    {
        public List<AbstractCondition> conditions = new List<AbstractCondition>();
        public List<Boolean> boolList = new List<bool>();

        public ConditionOr(List<AbstractCondition> conditions, string result)
        {
            this.conditions = conditions;
            this.result = result;
        }

        public override bool isTruth()
        {
            foreach (AbstractCondition condition in conditions)
            {
                if (condition is Condition)
                {
                    var simpleCondition = condition as Condition;
                    var isInFacts = KnowledgeBase.facts.
                        Where(p => p.Property == simpleCondition.condition).
                        ToList().
                        Count > 0;
                    if (isInFacts) return true;
                }
                boolList.Add(condition.isTruth());
            }
            return boolList.Where(p => p == true).ToList().Count > 0;
        }
    }
}
