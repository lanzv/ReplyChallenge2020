using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReplyChallenge2020
{
    class ReplyChallenge
    {
        public Reader reader { get; } = new Reader(Program.INPUT_FILE);
        // public StreamWriter writer { get; } = new StreamWriter(Program.OUTPUT_FILE);





        //TODO: Add data corresponding to input
        public int W { get; private set; }
        public int H { get; private set; }


        /// <summary>
        /// [0,0] [1,0] [2,0] <br />
        /// [0,1] [1,1] [2,1] <br />
        /// [0,2] [1,2] [2,2] <br />
        /// </summary>
        public char[,] Map { get; private set; }

        public Person[,] MapOfPersons { get; set; }



        public int NumberOfDevelopers { get; private set; }
        public int NumberOfManagers { get; private set; }


        // MOZNA JE DOBRY NAPAD MISTO LISTU DAT DALSI DICTIONARY NEBO TAK NECO 
        public Dictionary<string, List<Developer>> Skills { get; private set; }
        public Dictionary<string, List<Person>> Companies { get; private set; }


        public Developer[] Developers { get; private set; }
        public Manager[] Managers { get; private set; }












        public ReplyChallenge()
        {
            LoadData();
        }








        //Load data from input file
        private void LoadData()
        {
            W = Loader.GetNumber(reader);
            H = Loader.GetNumber(reader);
            Map = Loader.GetMap(reader, W, H);
            Developers = Loader.GetDevelopers(reader);
            Managers = Loader.GetManagers(reader);
            Companies = Loader.GetCompanies(Developers, Managers);
            Skills = Loader.GetSkills(Developers);
        }





        //Run algorithm to prepare output data
        public void Run()
        {
            
            MapOfPersons = new Person[W, H];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (Map[j, i] == 'M')
                    {
                        //UPPER PERSON
                        Person p1 = null;
                        int score1 = 0;
                        //LEFTER PERSON
                        Person p2 = null;
                        int score2 = 0;

                        //UP
                        if (j != 0 && MapOfPersons[j - 1, i] != null)
                        {
                            //M&M
                            if (MapOfPersons[j - 1, i] is Manager)
                            {
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score1 < tmp_score)
                                        {
                                            score1 = tmp_score;
                                            p1 = per;
                                        }
                                    }
                                }
                            }
                            else if (MapOfPersons[j - 1, i] is Developer)
                            {
                                //M&D
                                foreach (Person per in Developers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score1 < tmp_score)
                                        {
                                            score1 = tmp_score;
                                            p1 = per;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //UP is wall

                            score1 = -1;
                            /*
                            int k = 0;
                            while(Managers[k].IsUsed){
                                k++;
                            }
                            p1 = Managers[k];
							*/
                        }

                        //LEFT
                        if (i != 0 && MapOfPersons[j, i - 1] != null)
                        {
                            if (MapOfPersons[j, i - 1] is Manager)
                            {
                                //M&M
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score2 < tmp_score)
                                        {
                                            score2 = tmp_score;
                                            p2 = per;
                                        }
                                    }
                                }
                            }
                            else if (MapOfPersons[j, i - 1] is Developer)
                            {
                                //M&D
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score2 < tmp_score)
                                        {
                                            score2 = tmp_score;
                                            p2 = per;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //LEFT is Wall
                            score2 = -1;
                            /*
                            int k = 0;
                            while(Managers[k].IsUsed){
                                k++;
                            }
                            m2 = Managers[k];
							*/
                        }


                        if (score1 > score2)
                        {
                            if (p1 == null) continue;
                            MapOfPersons[j, i] = p1;
                            p1.IsUsed = true;
                            p1.X = j;
                            p1.Y = i;
                        }
                        else
                        {
                            if (p2 == null) continue;
                            MapOfPersons[j, i] = p2;
                            p2.IsUsed = true;
                            p2.X = j;
                            p2.Y = i;
                        }
                    }
                    else if (Map[j, i] == '_')
                    {
                        Person p1 = null;
                        int score1 = 0;
                        Person p2 = null;
                        int score2 = 0;


                        if (j != 0 && MapOfPersons[j - 1, i] != null)
                        {
                            if (MapOfPersons[j - 1, i] is Manager)
                            {
                                //D&M
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score1 < tmp_score)
                                        {
                                            score1 = tmp_score;
                                            p1 = per;
                                        }
                                    }
                                }
                            }
                            else if (MapOfPersons[j - 1, i] is Developer)
                            {
                                //D&D
                                foreach (Person per in Developers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetWorkPotential(per as Developer, MapOfPersons[j - 1, i] as Developer);

                                        if (score1 < tmp_score)
                                        {
                                            score1 = tmp_score;
                                            p1 = per;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //UP IS WALL
                            score1 = -1;
                            /*
                            int k = 0;
                            while(Developers[k].IsUsed){
                                k++;
                            }
                            d1 = Developers[k];
							*/
                        }


                        if (i != 0 && MapOfPersons[j, i - 1] != null)
                        {
                            if (MapOfPersons[j, i - 1] is Manager)
                            {
                                //D&M
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j - 1, i]);

                                        if (score2 < tmp_score)
                                        {
                                            score2 = tmp_score;
                                            p2 = per;
                                        }
                                    }
                                }
                            }
                            else if (MapOfPersons[j, i - 1] is Developer)
                            {
                                //D&D
                                foreach (Person per in Developers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        int tmp_score = Scores.GetWorkPotential(per as Developer, MapOfPersons[j - 1, i] as Developer);

                                        if (score2 < tmp_score)
                                        {
                                            score2 = tmp_score;
                                            p2 = per;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //LEFT IS WALL
                            score2 = -1;
                            /*
                            int k = 0;
                            while(Developers[k].IsUsed){
                                k++;
                            }
                            d2 = Developers[k];
							*/
                        }


                        if (score1 > score2)
                        {
                            if (p1 == null) continue;
                            MapOfPersons[j, i] = p1;
                            p1.IsUsed = true;
                            p1.X = j;
                            p1.Y = i;
                        }
                        else
                        {
                            if (p1 == null) continue;
                            MapOfPersons[j, i] = p2;
                            p2.IsUsed = true;
                            p2.X = j;
                            p2.Y = i;
                        }


                    }
                }
            }
        }






        public void GenerateOutputFile()
        {
            using (StreamWriter sw = new StreamWriter(Program.OUTPUT_FILE))
            {
                foreach (Developer dev in Developers)
                {
                    if (!dev.IsUsed)
                        sw.WriteLine("X");
                    else
                    {
                        sw.Write(dev.Y + " " + dev.X);
                        sw.WriteLine();
                    }
                }

                foreach (var man in Managers)
                {
                    if (!man.IsUsed)
                        sw.WriteLine("X");
                    else
                    {
                        sw.Write(man.Y + " " + man.X);
                        sw.WriteLine();
                    }
                }
            }
        }




        public void EZRun()
        {
            MapOfPersons = new Person[W, H];

            //"EZ" algorithm
            for (int height = 0; height < H; height++)
            {
                for (int width = 0; width < W; width++)
                {
                    switch (Map[width, height])
                    {
                        case 'M':
                            Manager chosen = EzRun_FindDev_highestBonus();

                            if (width - 1 >= 0 && height >= 0)
                            {
                                if (MapOfPersons[width - 1, height] != null)
                                {
                                    foreach (var mang in Companies[MapOfPersons[width - 1, height].Company])
                                    {
                                        if (!mang.IsUsed && mang is Manager)
                                            chosen = (Manager)mang;
                                    }
                                }
                            }

                            if (width >= 0 && height - 1 >= 0)
                            {
                                if (MapOfPersons[width, height - 1] != null)
                                {
                                    foreach (var mang in Companies[MapOfPersons[width, height - 1].Company])
                                    {
                                        if (!mang.IsUsed && mang is Manager)
                                            chosen = (Manager)mang;
                                    }
                                }
                            }

                            if (!chosen.IsUsed)
                            {
                                chosen.IsUsed = true;
                                chosen.X = height;
                                chosen.Y = width;
                            }
                            break;

                        case '_':
                            Developer chosenDev = EzRun_FindDev_highestNumOfSkills();

                            if (width - 1 >= 0 && height >= 0)
                            {
                                if (MapOfPersons[width - 1, height] != null)
                                {
                                    foreach (var mang in Companies[MapOfPersons[width - 1, height].Company])
                                    {
                                        if (!mang.IsUsed && mang is Developer)
                                            chosenDev = (Developer)mang;
                                    }
                                }
                            }

                            if (width >= 0 && height - 1 >= 0)
                            {
                                if (MapOfPersons[width, height - 1] != null)
                                {
                                    foreach (var mang in Companies[MapOfPersons[width, height - 1].Company])
                                    {
                                        if (!mang.IsUsed && mang is Developer)
                                            chosenDev = (Developer)mang;
                                    }
                                }
                            }

                            if (!chosenDev.IsUsed)
                            {
                                chosenDev.IsUsed = true;
                                chosenDev.X = height;
                                chosenDev.Y = width;
                            }

                            break;

                    }
                }
            }
        }

        public Developer EzRun_FindDev_highestNumOfSkills()
        {
            Developer chosen = Developers[0];

            if (chosen.IsUsed)
                for (int i = 1; i < Developers.Length; i++)
                {
                    if (!Developers[i].IsUsed)
                        chosen = Developers[i];
                }

            int best = 0;
            foreach (var dev in Developers)
            {
                if (dev.NumberOfSkills > best)
                    chosen = dev;
            }


            return chosen;
        }

        public Manager EzRun_FindDev_highestBonus()
        {
            Manager chosen = Managers[0];

            if (chosen.IsUsed)
                for (int i = 1; i < Managers.Length; i++)
                {
                    if (!Managers[i].IsUsed)
                        chosen = Managers[i];
                }

            int best = 0;
            foreach (var man in Managers)
            {
                if (man.Bonus > best)
                    chosen = man;
            }

            return chosen;
        }
    }
}
