using EbxTest.Clients.External;
using EbxTest.Models.External.GitHub;
using MediatR;

namespace EbxTest.Queries;

public class ContributorsHandler : IRequestHandler<ContributorsQuery, IEnumerable<Commit>>
{
    private readonly IGithubClient _githubClient;

    public ContributorsHandler(IGithubClient githubClient)
    {
        _githubClient = githubClient;
    }

    public async Task<IEnumerable<Commit>> Handle(
        ContributorsQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _githubClient.GetCommits(request.Owner, request.Repo, request.ResultCount, 1);
        
        return response.Select(c => c.Commit);
    }
}