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

        public char[,] Map

        public int someInt { get; private set; }
        public int[] someIntData { get; private set; }
        public string[] someStringData { get; private set; }

        //TODO: Add data corresponding to output ... optional
        public int[] someIntOutputData { get; private set; }








        public ReplyChallenge()
        {
            LoadData();
        }








        //Load data from input file
        private void LoadData()
        {
            //TODO: Load data corresponding to input file
            someInt = Loader.GetNumber(reader);
            someIntData = Loader.GetNNumbers(reader, someInt);
        }


        //Print result, some part,... 
        public void PrintSomething(object something)
        {
            //TODO: Print "Something" data
            Printer.PrintNumber(writer, someInt);
            Printer.PrintNumbers(writer, someIntData);
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
    }
}
