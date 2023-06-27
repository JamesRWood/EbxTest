namespace EbxTest.Models.External.GitHub;

public class Commit
{
    public string Message { get; set; }
    
    public Committer Committer { get; set; }
}