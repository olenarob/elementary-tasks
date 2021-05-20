using System;
using System.IO;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            int nextByte;
            string s = args[1];
            int count = 0;

            using (FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);

                while ((nextByte = fs.ReadByte()) > 0)
                {
                    char tmp = Convert.ToChar(nextByte);
                    if (tmp == s[0])
                    {
                        int i;
                        string s1 = "" + s[0];
                        for (i = 1; i < s.Length; i++)
                        {
                            if ((nextByte = fs.ReadByte()) > 0)
                            {
                                tmp = Convert.ToChar(nextByte);
                            }
                            else
                            {
                                break;
                            }

                            if (tmp == s[i])
                            {
                                s1 += tmp;
                            }
                            else
                            {
                                break;
                            }    
                        }

                        if (s1 == s)
                        {
                            count++;
                        }

                        fs.Seek(-(i-1), SeekOrigin.Current);
                    }
                }
            }
            Console.WriteLine(@$"There are {count} strings ""{s}"" in {args[0]}.");
        }
    }
}
