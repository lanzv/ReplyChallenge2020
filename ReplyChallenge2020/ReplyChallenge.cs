using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReplyChallenge2020
{
    class ReplyChallenge
    {
        public Reader reader { get; } = new Reader(Program.INPUT_FILE);
        //public StreamWriter writer { get; } = new StreamWriter(Program.OUTPUT_FILE);





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
                        sw.WriteLine('X');
                    else
                    {
                        sw.Write(dev.Y + " " + dev.X);
                        sw.WriteLine();
                    }
                }

                foreach (var man in Managers)
                {
                    if (!man.IsUsed)
                        sw.WriteLine('X');
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
            //"EZ" algorithm
            for(int i = 0; i < H; i++){
                for(int j = 0; j < W; j++){
                    if(Map[j,i] == 'M')
                    {
                        int k = 0;
                        while(k < Managers.Length && Managers[k].IsUsed){
                            k++;
                        }
                        if(k < Managers.Length)
                        {
                            Managers[k].IsUsed = true;
                            Managers[k].X = i;
                            Managers[k].Y = j;
                        }
                    }
                    else if(Map[j, i] == '_')
                    {
                        
                        int k = 0;
                        while (k <Developers.Length && Developers[k].IsUsed){
                            k++;
                        }
                        if(k < Developers.Length)
                        {
                            Developers[k].IsUsed = true;
                            Developers[k].X = i;
                            Developers[k].Y = j;
                        }
                    }
                }
            }
        }
    }

}
