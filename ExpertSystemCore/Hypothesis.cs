using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public class Hypothesis
    {
        #region fields
        private string obj;
        private string value;
        #endregion

        #region properties
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Obj
        {
            get { return obj; }
            set { obj = value; }
        }
        #endregion

        #region constructors
        public Hypothesis(string obj, string value)
        {
            this.obj = obj;
            this.value = value;
        }
        public Hypothesis() { }
        #endregion
    }
}
