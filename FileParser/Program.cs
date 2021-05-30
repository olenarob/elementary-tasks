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
