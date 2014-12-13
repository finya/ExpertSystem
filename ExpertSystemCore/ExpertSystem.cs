using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public class ExpertSystem
    {
        public bool checkHypothesis(string obj, string value)
        {
            try
            {
                var hypothesis = new Hypothesis(obj, value);
                var startCondition = KnowledgeBase.Conditions.Where(p => p.result == hypothesis.Value).ToList()[0];
                return startCondition.isTruth(hypothesis);
            }
            catch
            {
                return false;
            }
        }
    }
}
