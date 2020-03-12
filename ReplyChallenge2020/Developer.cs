using System;
using System.Collections.Generic;
using System.Text;

namespace ReplyChallenge2020
{
    class Developer:Person
    {
        public int NumberOfSkills { get; }
        public string[] Skills { get; }

        public Developer(string company, int bonus, int numberOfSkills, string[] skills):base(company, bonus)
        {
            NumberOfSkills = numberOfSkills;
            Skills = skills;
        }

    }
}
