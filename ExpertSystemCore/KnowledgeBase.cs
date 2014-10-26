using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystemCore
{
    public class KnowledgeBase
    {
        public static List<Fact> facts = new List<Fact>();
        public static List<AbstractCondition> conditions = new List<AbstractCondition>();

        static KnowledgeBase()
        {
            // TEST VALUES MAZAFAKA
            // гипотеза ТАЩИТЬ ДОМОЙ
            facts.Add(new Fact("красное"));
            facts.Add(new Fact("можно поднять"));
            conditions.Add(new Condition("хорошее", "тащить домой"));
            conditions.Add(new Condition("красное", "хорошее"));
            conditions.Add(new Condition("можно поднять", "легкое"));
        }

    }

    public class Fact
    {
        private string property;

        public string Property
        {
            get { return property; }
        }

        public Fact(string property)
        {
            this.property = property;
        }


    }
}
