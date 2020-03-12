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
            while (true)
            {
                //... 
                GetPotentionalScoreOfSomething(new object());
                PrintSomething(new object());
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
			StreamWriter sw = new StreamWriter(Program.OUTPUT_FILE);
			
			foreach(Developer dev in Developers)
			{
				if (!dev.IsUsed)
					sw.WriteLine('X');
				else
				{
					sw.Write(dev.X + ' ' + dev.Y);
					sw.WriteLine();
				}
			}

			foreach(var man in Managers)
			{
				if (!man.IsUsed)
					sw.WriteLine('X');
				else
				{
					sw.Write(man.X + ' ' + man.Y);
					sw.WriteLine();
				}
			}

		}
    }
}
