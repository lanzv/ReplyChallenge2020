using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReplyChallenge2020
{
    class ReplyChallenge
    {
        public Reader reader { get; } = new Reader(Program.INPUT_FILE);
        public StreamWriter writer { get; } = new StreamWriter(Program.OUTPUT_FILE);





        //TODO: Add data corresponding to input
        public int W { get; private set; }
        public int H { get; private set; }


        /// <summary>
        /// [0,0] [1,0] [2,0] <br />
        /// [0,1] [1,1] [2,1] <br />
        /// [0,2] [1,2] [2,2] <br />
        /// </summary>
        public char[,] Map { get; private set; }

        public Person[,] MapOfPersons {get;set;}



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
        }


        //Print result, some part,... 
        public void PrintSomething(object something)
        {
            //TODO: Print "Something" data

        }





        //Run algorithm to prepare output data
        public void Run()
        {
            //TODO: Some algorithm (bruteforce, apod ...) 
            MapOfPersons = new Person[H, W];
            for(int i = 0; i < H; i++){
                for(int j = 0; j < W; j++){
                    if(Map[j,i] == 'M')
                    {
						//UPPER PERSON
						Person p1 = null;
						int score1 = 0;
						//LEFTER PERSON
						Person p2 = null;
						int score2 = 0;

						//UP
                        if(j != 0 && MapOfPersons[j, i - 1] != null)
                        {
							//M&M
                            if(MapOfPersons[j, i - 1] is Manager)
                            {
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p1 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Managers)
								{
                                    if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j, i - 1]);

										if (score1 < tmp_score)
										{
											score1 = tmp_score;
											p1 = per;
										}
									}
								}
							}
                            else if(MapOfPersons[j, i - 1] is Developer)
                            {
                                //M&D
                                foreach (Person per in Developers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p1 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Developers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j, i - 1]);

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
                        if(i != 0 && MapOfPersons[j - 1, i ] != null)
                        {
                            if(MapOfPersons[j - 1, i] is Manager)
                            {
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p2 = per;
                                        break;
                                    }
                                }

                                //M&M
                                foreach (Person per in Managers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j, i - 1]);

										if (score2 < tmp_score)
										{
											score2 = tmp_score;
											p2 = per;
										}
									}
								}
							}
                            else if(MapOfPersons[j - 1, i] is Developer)
                            {
                                //M&D
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p2 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Managers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[j, i - 1]);

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
                        if (score1 == -1 && score2 == -1)
                        {
                            p1 = Developers[0];
                            MapOfPersons[i, j] = p1;
                            p1.IsUsed = true;
                            p1.X = j;
                            p1.Y = i;
                        }
                        else
                        if (score1 > score2){
							if (p1 == null) throw new Exception("p1 should not be null --- chyba je ve vypoèitavani score1");
                            MapOfPersons[j,i] = p1;
                            p1.IsUsed = true;
                            p1.X = j;
                            p1.Y = i;
                        }else{
							if (p2 == null) throw new Exception("p2 should not be null --- chyba je ve vypoèitavani score1");
							MapOfPersons[j,i] = p2;
                            p2.IsUsed = true;
                            p2.X = j;
                            p2.Y = i;
                        }
                    }
                    else if(Map[j,i] == '_')
                    {
						Person p1 = null;
						int score1 = 0;
						Person p2 = null;
						int score2 = 0;


                        if(j != 0 && MapOfPersons[i, j - 1] != null)
                        {
                            if(MapOfPersons[i, j - 1] is Manager)
                            {
                                //D&M
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p1 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Managers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[i, j - 1]);

										if (score1 < tmp_score)
										{
											score1 = tmp_score;
											p1 = per;
										}
									}
								}
							}
                            else if(MapOfPersons[i, j - 1] is Developer)
                            {
                                //D&D
                                foreach (Person per in Developers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p1 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Developers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetWorkPotential(per as Developer, MapOfPersons[i, j - 1] as Developer);

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


                        if(i != 0 && MapOfPersons[i - 1, j] != null)
                        {
                            if(MapOfPersons[i - 1, j] is Manager)
                            {
                                //D&M
                                foreach (Person per in Managers)
                                {
                                    if (!per.IsUsed)
                                    {
                                        p2 = per;
                                        break;
                                    }
                                }

                                foreach (Person per in Managers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetBonusPotential(per, MapOfPersons[i, j - 1]);

										if (score2 < tmp_score)
										{
											score2 = tmp_score;
											p2 = per;
										}
									}
								}
							}
                            else if(MapOfPersons[i - 1, j] is Developer)
                            {
								//D&D
								foreach (Person per in Developers)
								{
									if (!per.IsUsed)
									{
										int tmp_score = Scores.GetWorkPotential(per as Developer, MapOfPersons[i, j - 1] as Developer);

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

                        if (score1 == -1 && score2 == -1)
                        {
                            foreach (Person per in Developers)
                            {
                                if (!per.IsUsed)
                                {
                                    p1 = per;
                                    break;
                                }
                            }

                            foreach (Person per in Developers)
                            {
                                if (!per.IsUsed)
                                {
                                    p2 = per;
                                    break;
                                }
                            }
                        }
                        else
                        if(score1 > score2){
							if (p1 == null) throw new Exception("p1 should not be null --- chyba je ve vypoèitavani score1");
							MapOfPersons[i,j] = p1;
                            p1.IsUsed = true;
                            p1.X = j;
                            p1.Y = i;
                        }else{
							if (p2 == null) throw new Exception("p2 should not be null --- chyba je ve vypoèitavani score1");
							MapOfPersons[i,j] = p2;
                            p2.IsUsed = true;
                            p2.X = j;
                            p2.Y = i;
                        }


                    }
                }
            }
        }



        //Get score to compare results
        private int GetPotentionalScoreOfSomething(object something)
        {
            //TODO: algorithm to get score
            return Scores.GetScoreOfSomething(this);
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
						sw.Write(dev.X + " " + dev.Y);
						sw.WriteLine();
					}
				}

				foreach (var man in Managers)
				{
					if (!man.IsUsed)
						sw.WriteLine("X");
					else
					{
						sw.Write(man.X + " " + man.Y);
						sw.WriteLine();
					}
				}
			}
		}
    }
}
