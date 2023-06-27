using EbxTest.Models.External.GitHub;
using MediatR;

namespace EbxTest.Queries;

public class ContributorsWithinPeriodQuery : IRequest<IEnumerable<Commit>>
{
    public ContributorsWithinPeriodQuery(string owner, string repo, int daySpan)
    {
        Owner = owner;
        Repo = repo;
        DaySpan = daySpan;
    }
    
    public string Owner { get; }
    
    public string Repo { get; }

    public int DaySpan { get; }
}