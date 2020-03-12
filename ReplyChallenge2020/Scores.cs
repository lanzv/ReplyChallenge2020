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


        public static int GetTotalPotential(Person per1, Person per2)
        {
            if (per1 is Developer dev1 && per2 is Developer dev2)
                return GetBonusPotential(dev1, dev2) + GetWorkPotential(dev1, dev2);

            return GetBonusPotential(per1, per2);
        }

        public static int GetBonusPotential(Person per1, Person per2)
        {
            if (per1.Company == per2.Company)
                return per1.Bonus * per2.Bonus;

            return 0;
        }

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

        public class GaussianRandom
        {
            private bool _hasDeviate;
            private double _storedDeviate;
            private readonly Random _random;

            public GaussianRandom(Random random = null)
            {
                _random = random ?? new Random();
            }

            /// <summary>
            /// Obtains normally (Gaussian) distributed random numbers, using the Box-Muller
            /// transformation.  This transformation takes two uniformly distributed deviates
            /// within the unit circle, and transforms them into two independently
            /// distributed normal deviates.
            /// </summary>
            /// <param name="mu">The mean of the distribution.  Default is zero.</param>
            /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
            /// <returns></returns>
            public double NextGaussian(double mu = 0, double sigma = 1)
            {
                if (sigma <= 0)
                    throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");

                if (_hasDeviate)
                {
                    _hasDeviate = false;
                    return _storedDeviate * sigma + mu;
                }

                double v1, v2, rSquared;
                do
                {
                    // two random values between -1.0 and 1.0
                    v1 = 2 * _random.NextDouble() - 1;
                    v2 = 2 * _random.NextDouble() - 1;
                    rSquared = v1 * v1 + v2 * v2;
                    // ensure within the unit circle
                } while (rSquared >= 1 || rSquared == 0);

                // calculate polar tranformation for each deviate
                var polar = Math.Sqrt(-2 * Math.Log(rSquared) / rSquared);
                // store first deviate
                _storedDeviate = v2 * polar;
                _hasDeviate = true;
                // return second deviate
                return Math.Abs(v1 * polar * sigma + mu);
            }
        }

        public static int GetScoreOfSomething(ReplyChallenge RC)
        {
            //TODO: some algorithm to count score
            return 0;
        }
    }
}
