using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public class SimpleCondition: AbstractCondition
    {
        private string condition;

        public SimpleCondition(string condition, string result)
        {
            this.condition = condition;
            this.result = result;
        }

        public override bool isTruth(Hypothesis hyp)
        {
            var isInFacts = KnowledgeBase.Facts.
                Where(p => p.Property == hyp.Obj+ " "+ condition).
                ToList().Count > 0;
            if (isInFacts) return true;
            var nextCondition = KnowledgeBase.Conditions.Where(p => p.result == condition).ToList();
            if (nextCondition.Count == 0) return false;
            return nextCondition[0].isTruth(hyp);
        }
    }
}
