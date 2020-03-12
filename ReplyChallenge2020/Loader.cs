using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReplyChallenge2020
{
    class Loader
    {
        //TODO: create methods to get data corresponding to input, for example "GetBooks"
        public static int[] GetNNumbers(Reader reader, int N)
        {
            int[] numbers = new int[N];
            for (int i = 0; i < N; i++)
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

        public static char[,] GetMap(Reader reader, int width, int height)
        {
            char field;
            bool legitchar;
            char[,] map = new char[width, height];
            for (int h = height - 1; h >= 0; h--)
            {
                for (int w = 0; w < width; w++)
                {
                    legitchar = false;
                    while (!legitchar)
                    {
                        reader.Char(out field);
                        switch (field)
                        {
                            case '#':
                            case '_':
                            case 'M':
                                map[w, h] = field;
                                legitchar = true;
                                break;
                            case '\r':
                            case '\n':
                                reader.Char(out field);
                                legitchar = false;
                                break;
                            default:
                                Console.WriteLine("Dusa je kokot, press enter");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
            }

            return map;
        }
    }
}
