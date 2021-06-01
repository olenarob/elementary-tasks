namespace FileParser
{
    public interface IFileParser
    {
        void SearchInFile(string sourceFileName, string lineToSearch);
        void ReplaceInFile(string sourceFileName, string lineToSearch, string lineToReplace);
    }
}
