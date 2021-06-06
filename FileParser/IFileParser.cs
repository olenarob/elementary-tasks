namespace FileParser
{
    public interface IFileParser
    {
        string SearchInFile(string sourceFileName, string lineToSearch);
        string ReplaceInFile(string sourceFileName, string lineToSearch, string lineToReplace);
        string FileToString(string sourceFileName);
    }
}
