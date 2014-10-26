using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public abstract class AbstractCondition
    {
        public string result;
        public virtual bool isTruth()
        {
            return true;
        }
    }
}
