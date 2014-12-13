using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ExpertSystemCore
{
    public static class KnowledgeBase
    {
        #region fields
        private static ObservableCollection<Fact> facts = new ObservableCollection<Fact>();
        private static ObservableCollection<AbstractCondition> conditions = new ObservableCollection<AbstractCondition>();
        #endregion

        #region properties
        public static ObservableCollection<Fact> Facts
        {
            get { return facts; }
            set { facts = value; }
        }

        public static ObservableCollection<AbstractCondition> Conditions
        {
            get { return conditions; }
            set { conditions = value; }
        }
        #endregion

        public static void resetBase()
        {
            facts = new ObservableCollection<Fact>();
            conditions = new ObservableCollection<AbstractCondition>();
        }
    }


    public class Fact
    {
        private string property;
        private string obj;

        public string Property
        {
            get { return obj + " " + property; }
        }

        public Fact(string property, string obj)
        {
            this.property = property;
            this.obj = obj;
        }
    }
}
