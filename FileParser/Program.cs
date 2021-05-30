using System;
using System.IO;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                switch (args.Length)
                {
                    case 2:
                        CountInFile(args[0], args[1]);
                        SearchInFile(args[0], args[1]);
                        break;
                    case 3:
                        ReplaceInFile(args[0], args[1], args[2]);
                        Console.WriteLine($"FileParser has completed the processing of {args[0]}.");
                        break;
                    default:
                        Help();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Help();
            }
            
        }

        private static void Help()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("1.<path> <string to count>");
            Console.WriteLine("2.<path> <string to search> <string to replace>");
        }

        private static void CountInFile(string sourceFileName, string lineToSearch)
        {
            int nextByte;
            string s = lineToSearch;
            int count = 0;

            using (var fs = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read))
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
            Console.WriteLine(@$"There are {count} strings ""{s}"" in {sourceFileName}.");
        }

        private static void SearchInFile(string sourceFileName, string lineToSearch)
        {
            try
            {
                using (var reader = new StreamReader(sourceFileName))
                {
                    int count = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        count += line.Split(lineToSearch).Length - 1;
                    }
                    Console.WriteLine(@$"There are {count} strings ""{lineToSearch}"" in {sourceFileName}.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Usage: <path> <string to count>");
            }
        }
        private static void ReplaceInFile(string sourceFileName, string lineToSearch, string lineToReplace)
        {
            
            string tmpFileName = Path.Combine(Path.GetDirectoryName(sourceFileName), "tmp.txt");

            using (var writer = new StreamWriter(tmpFileName))
            {
                using (var reader = new StreamReader(sourceFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string newLine = line.Replace(lineToSearch, lineToReplace);
                        writer.WriteLine(newLine);
                    }
                }
            }

            File.Copy(tmpFileName, sourceFileName, true);
            File.Delete(tmpFileName);
        }
    }
}
