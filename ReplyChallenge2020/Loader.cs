using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ReplyChallenge2020
{
    class Loader
    {
        //TODO: create methods to get data corresponding to input, for example "GetBooks"
        public static int[] GetNNumbers(Reader reader, int N)
        {
            int[] numbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                reader.Int(out numbers[i]);
            }
            return numbers;
        }

        public static int GetNumber(Reader reader)
        {
            int n;
            reader.Int(out n);
            return n;
        }

        public static char[,] GetMap(Reader reader, int width, int height)
        {
            char field;
            bool legitchar;
            char[,] map = new char[width, height];
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    legitchar = false;
                    while (!legitchar)
                    {
                        reader.Char(out field);
                        switch (field)
                        {
                            case '#':
                            case '_':
                            case 'M':
                                map[w, h] = field;
                                legitchar = true;
                                break;
                            case '\r':
                            case '\n':
                                reader.Char(out field);
                                legitchar = false;
                                break;
                            default:
                                Console.WriteLine("Dusa je kokot, press enter");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
            }

            return map;
        }

        public static Developer[] GetDevelopers(Reader reader)
        {

            reader.Int(out int numberOfDevelopers);
            Developer[] devs = new Developer[numberOfDevelopers];

            string company;
            int bonus;
            int numberOfSkills;
            string[] skills;

            for (int i = 0; i < numberOfDevelopers; i++)
            {
                company = reader.Word();
                reader.Int(out bonus);
                reader.Int(out numberOfSkills);

                skills = new string[numberOfSkills];

                for (int j = 0; j < numberOfSkills; j++)
                {
                    skills[j] = reader.Word();
                }

                devs[i] = new Developer(company, bonus, numberOfSkills, skills);
            }


            return devs;
        }

        public static Manager[] GetManagers(Reader reader)
        {
            reader.Int(out int numOfManagers);
            Manager[] managers = new Manager[numOfManagers];
            string company;
            int bonus;

            for (int i = 0; i < numOfManagers; i++)
            {
                company = reader.Word();
                reader.Int(out bonus);

                managers[i] = new Manager(company, bonus);
            }

            return managers;
        }

        public static Dictionary<string, List<Person>> GetCompanies(Developer[] devs, Manager[] mags)
        {
            var returnVal = new Dictionary<string, List<Person>>();

            foreach (var dev in devs)
            {
                if (returnVal.ContainsKey(dev.Company))
                {
                    returnVal[dev.Company].Add(dev);
                }
                else
                {
                    returnVal.Add(dev.Company, new List<Person> { dev });
                }
            }

            return returnVal;
        }

        public static Dictionary<string, List<Developer>> GetSkills(Developer[] devs)
        {
            var returnVal = new Dictionary<string, List<Developer>>();

            foreach (var dev in devs)
            {
                foreach (var skill in dev.Skills)
                {
                    if (returnVal.ContainsKey(skill))
                    {
                        returnVal[skill].Add(dev);
                    }
                    else
                    {
                        returnVal.Add(skill, new List<Developer> {dev});
                    }
                }
            }

            return returnVal;
        }
    }
}
