using EbxTest.Models.External.GitHub;
using MediatR;

namespace EbxTest.Queries;

public class ContributorsQuery : IRequest<IEnumerable<Commit>>
{
    public ContributorsQuery(string owner, string repo, int resultCount)
    {
        Owner = owner;
        Repo = repo;
        ResultCount = resultCount;
    }
    
    public string Owner { get; }
    
    public string Repo { get; }

    public int ResultCount { get; }
}