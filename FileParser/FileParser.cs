using System;
using System.IO;

namespace FileParser
{
    class FileParser : IFileParser
    {
        private char[] separators = new char[] { ' ', ',', '.', '?', '!' };
        public string SearchInFile(string sourceFileName, string lineToSearch)
        {
            using (var reader = new StreamReader(sourceFileName))
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
                return @$"There are {count} strings ""{lineToSearch}"" in {sourceFileName}.";
            }
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
    }
}
