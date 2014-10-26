using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    class Condition: AbstractCondition
    {
        public string condition;

        public Condition(string condition, string result)
        {
            this.condition = condition;
            this.result = result;
        }

        public override bool isTruth()
        {
            var isInFacts = KnowledgeBase.facts.Where(p => p.Property == condition).ToList().Count > 0;
            if (isInFacts) return true;
            var nextCondition = KnowledgeBase.conditions.Where(p => p.result == condition).ToList();
            if (nextCondition.Count == 0) return false;
            return nextCondition[0].isTruth();
        }
    }
}
