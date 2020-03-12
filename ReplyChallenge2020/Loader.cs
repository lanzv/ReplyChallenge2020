using System;
using System.Collections.Generic;
using System.Text;

namespace ReplyChallenge2020
{
    class Loader
    {
        //TODO: create methods to get data corresponding to input, for example "GetBooks"
        public static int[] GetNNumbers(Reader reader, int N)
        {
            int[] numbers = new int[N];
            for(int i = 0; i < N; i++)
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

        public static char[,] GetMap(Reader reader)
        {

            return null;
        }
    }
}
