using System;
using System.Collections.Generic;
using System.Text;

namespace ReplyChallenge2020
{
    class Person
    {
        public int Bonus { get; }
        public string Company { get; }
        public bool IsUsed {get; set;}
        public int X;
        public int Y;

        public Person(string company, int bonus)
        {
            Company = company;
            Bonus = bonus;
            IsUsed = false;
        }
    }
}
