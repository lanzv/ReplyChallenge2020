using System;
using System.Collections.Generic;
using System.Text;

namespace ReplyChallenge2020
{
    class Scores
    {
        // PLAN
            // nahore person - vyberu per z company 
            // nahore developer - vyberu developera podle WP 

        public static int GetWorkPotential(Developer dev1, Developer dev2)
        {
            HashSet<string> allSkills = new HashSet<string>();
            HashSet<string> commonSkills = new HashSet<string>();

            foreach (var dev1Skill in dev1.Skills)
            {
                allSkills.Add(dev1Skill);
               
                foreach (var dev2Skill in dev2.Skills)
                {
                    if (dev1Skill == dev2Skill)
                        commonSkills.Add(dev1Skill);
                    
                    allSkills.Add(dev2Skill);
                }
            }

            return commonSkills.Count * (allSkills.Count - commonSkills.Count);
        }

        public static int GetScoreOfSomething(ReplyChallenge RC)
        {
            //TODO: some algorithm to count score
            return 0;
        }
    }
}
