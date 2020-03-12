namespace ReplyChallenge2020
{
    public class Program
    {
        public static readonly string INPUT_FILE = "f.txt";
        public static readonly string OUTPUT_FILE = "output_f.txt";

        static void Main(string[] args)
        {
            ReplyChallenge RC = new ReplyChallenge();

            RC.EZRun();

            RC.GenerateOutputFile();
        }
    }
}