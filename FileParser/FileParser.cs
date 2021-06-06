using System;
using System.IO;

namespace FileParser
{
    class FileParser : IFileParser
    {
        private char[] separators = new char[] { ' ', ',', '.', '?', '!' };
        /*
        public string SearchInFile(string sourceFileName, string lineToSearch)
        {
            using (var reader = new StreamReader(sourceFileName, false))
            {
                int count = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(separators,StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (word == lineToSearch)
                        {
                            count++;
                        }
                    }
                }
                return @$"There are {count} words ""{lineToSearch}"" in {sourceFileName}.";
            }
        }
        */
        public string SearchInFile(string sourceFileName, string lineToSearch)
        {
            int count = 0;

            foreach (string line in File.ReadLines(sourceFileName))
            {
                string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word == lineToSearch)
                    {
                        count++;
                    }
                }
            }
            return @$"There are {count} words ""{lineToSearch}"" in {sourceFileName}.";
        }

        public string ReplaceInFile(string sourceFileName, string lineToSearch, string lineToReplace)
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

            return $"FileParser has completed the processing of {sourceFileName}.";
        }

        public string FileToString(string sourceFileName)
        {
            return File.ReadAllText(sourceFileName);
        }
    }
}
