using System;
using System.IO;

namespace FileParser
{
    class FileParser : IFileParser
    {
        public void SearchInFile(string sourceFileName, string lineToSearch)
        {
            using (var reader = new StreamReader(sourceFileName))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    /*if (true)
                    {
                        string tmpline = line.Split(new char[] { ' ', ',', '.', '?', '!' },
                            lineToSearch);
                    }*/
                    count += line.Split(lineToSearch).Length - 1;
                }
                Console.WriteLine(@$"There are {count} strings ""{lineToSearch}"" in {sourceFileName}.");
            }
        }
        public void ReplaceInFile(string sourceFileName, string lineToSearch, string lineToReplace)
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
