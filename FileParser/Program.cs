using System;
using System.IO;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 2:
                    SearchInFile(args);
                    break;
                case 3:
                    ReplaceInFile(args);
                    break;
                default:
                    Console.WriteLine("Usage:");
                    Console.WriteLine("1.<path> <string to count>");
                    Console.WriteLine("2.<path> <string to search> <string to replace");
                    break;
            } 
        }
                
        private static void CountInFile(string[] args)
        {
            int nextByte;
            string s = args[1];
            int count = 0;

            using (var fs = new FileStream(args[0], FileMode.Open, FileAccess.Read))
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

                        fs.Seek(-(i - 1), SeekOrigin.Current);
                    }
                }
            }
            Console.WriteLine(@$"There are {count} strings ""{s}"" in {args[0]}.");
        }

        private static void SearchInFile(string[] args)
        {
            try
            {
                using (var reader = new StreamReader(args[0]))
                {
                    // Redirect standard input from the console to the input file.
                    Console.SetIn(reader);
                    
                    int count = 0;
                    string line;
                    
                    while ((line = Console.ReadLine()) != null)
                    {
                        if (line.Contains(args[1]))
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(@$"There are {count} strings ""{args[1]}"" in {args[0]}.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Usage: <path> <string to count>");
            }
        }
        private static void ReplaceInFile(string[] args)
        {
            try
            {
                // Attempt to open output file.
                using (var writer = new StreamWriter("tmp.txt"))
                {
                    using (var reader = new StreamReader(args[0]))
                    {
                        // Redirect standard output from the console to the output file.
                        Console.SetOut(writer);
                        // Redirect standard input from the console to the input file.
                        Console.SetIn(reader);
                        string line;
                        while ((line = Console.ReadLine()) != null)
                        {
                            string newLine = line.Replace(args[1], args[2]);
                            Console.WriteLine(newLine);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                errorWriter.WriteLine("Usage: <path> <string to search> <string to replace");
            }

            // Recover the standard output stream so that a
            // completion message can be displayed.
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine($"FileParser has completed the processing of {args[0]}.");
        }
    }
}
