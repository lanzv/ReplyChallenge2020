using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReplyChallenge2020
{
    class Printer
    {        
        //TODO: create methods to print output data, for example "PrintLibrary"
        public static void PrintNumbers(StreamWriter writer, int[] numbers)
        {
            if(numbers.Length > 0)
            {
                writer.Write(numbers[0]);
                for(int i = 1; i < numbers.Length; i++)
                {
                    writer.Write(" " + numbers[0]);
                }
            }
        }
        public static void PrintNumber(StreamWriter writer, int number)
        {
            writer.Write(number);
        }
    }
}
