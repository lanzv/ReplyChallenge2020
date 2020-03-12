using System;

namespace ReplyChallenge2020
{
    public class Program
    {
        public static readonly string INPUT_FILE = "f.txt";
        public static readonly string OUTPUT_FILE = "output_6.txt";

        static void Main(string[] args)
        {
            ReplyChallenge RC = new ReplyChallenge();

            Reader reader = new Reader(INPUT_FILE);
            RC.EZRun();
            RC.GenerateOutputFile();
        }
    }
}
