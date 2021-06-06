using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class FileStreamParser
    {
        private char[] separators = new char[] { ' ', ',', '.', '?', '!' };

        private static void SearchInFile(string sourceFileName, string lineToSearch)
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
