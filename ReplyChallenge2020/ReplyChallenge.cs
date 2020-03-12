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
        /// [2,0] [2,1] [2,2] <br />
        /// [1,0] [1,1] [2,1] <br />
        /// [0,0] [1,0] [2,0] <br />
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

            //TODO Pracuju na tom, dusa, zatim vraci null
            Map = Loader.GetMap(reader, W, H);
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
            for(int i = 0; i < H; i--){
                for(int j = 0; j < W; j++){
                    if(Map[i,j] == "M")
                    {
                        Manager m1;
                        int score1;
                        Manager m2;
                        int score2;
                        if(i != 0 && MapOfPersons[i - 1, j] != null)
                        {
                            if(MapOfPersons[i - 1, j] is Manager)
                            {
                                //TODO
                            }
                            else if(MapOfPersons[i - 1, j] is Developer)
                            {
                                //TODO
                            }
                        }
                        else
                        {
                            int k = 0;
                            while(Managers[k].IsUsed){
                                k++;
                            }
                            m1 = Managers[k];
                        }

                        if(j != 0 && MapOfPersons[i, j - 1] != null)
                        {
                            if(MapOfPersons[i - 1, j] is Manager)
                            {
                               //TODO
                            }
                            else if(MapOfPersons[i - 1, j] is Developer)
                            {
                                //TODO
                            }
                        }
                        else
                        {
                            int k = 0;
                            while(Managers[k].IsUsed){
                                k++;
                            }
                            m2 = Managers[k];
                        }

                        
                        if(score1 > score2){
                            MapOfPersons[i,j] = d1;
                            d1.IsUsed = true;
                            d1.X = i;
                            d1.Y = j;
                        }else{
                            MapOfPersons[i,j] = d2;
                            d2.IsUsed = true;
                            d2.X = i;
                            d2.Y = j;
                        }
                    }
                    else if(Map[i,j] == "_")
                    {
                        Developer d1;
                        int score1;
                        Developer d2;
                        int score2;


                        if(i != 0 && MapOfPersons[i - 1, j] != null)
                        {
                            if(MapOfPersons[i - 1, j] is Manager)
                            {
                                //TODO
                            }
                            else if(MapOfPersons[i - 1, j] is Developer)
                            {
                                //TODO
                            }
                        }
                        else
                        {
                            int k = 0;
                            while(Developers[k].IsUsed){
                                k++;
                            }
                            d1 = Developers[k];
                        }


                        if(j != 0 && MapOfPersons[i, j - 1] != null)
                        {
                            if(MapOfPersons[i - 1, j] is Manager)
                            {
                                //TODO
                            }
                            else if(MapOfPersons[i - 1, j] is Developer)
                            {
                                //TODO
                            }
                        }
                        else
                        {
                            int k = 0;
                            while(Developers[k].IsUsed){
                                k++;
                            }
                            d2 = Developers[k];
                        }


                        if(score1 > score2){
                            MapOfPersons[i,j] = d1;
                            d1.IsUsed = true;
                            d1.X = i;
                            d1.Y = j;
                        }else{
                            MapOfPersons[i,j] = d2;
                            d2.IsUsed = true;
                            d2.X = i;
                            d2.Y = j;
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
    }
}
