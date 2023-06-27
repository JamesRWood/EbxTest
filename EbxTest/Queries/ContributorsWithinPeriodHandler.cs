using EbxTest.Clients.External;
using EbxTest.Models.External.GitHub;
using MediatR;

namespace EbxTest.Queries;

public class ContributorsWithinPeriodHandler : IRequestHandler<ContributorsWithinPeriodQuery, IEnumerable<Commit>>
{
    private readonly IGithubClient _githubClient;

    public ContributorsWithinPeriodHandler(IGithubClient githubClient)
    {
        _githubClient = githubClient;
    }

    public async Task<IEnumerable<Commit>> Handle(
        ContributorsWithinPeriodQuery request,
        CancellationToken cancellationToken)
    {
        var since = DateTime.UtcNow.AddDays(-request.DaySpan);
        var response = await _githubClient.GetCommits(request.Owner, request.Repo, 30, 1);
        
        return response.Select(c => c.Commit);
    }
}