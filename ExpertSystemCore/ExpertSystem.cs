using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public static class ExpertSystem
    {
        private static string gip;

        public static void Start()
        {
            gip = "тащить домой";
            var firstConditions = KnowledgeBase.conditions.Where(p => p.result == gip).ToList();
            foreach (AbstractCondition condition in firstConditions)
            {
                var azaza = condition.isTruth();
            }
        }
    }
}
