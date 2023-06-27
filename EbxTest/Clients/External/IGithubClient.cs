using EbxTest.Models.External.GitHub;
using Refit;

namespace EbxTest.Clients.External;

[Headers("Content-Type: application/vnd.github+json")]
public interface IGithubClient
{
    [Get("/repos/{owner}/{repo}/commits?per_page={pageSize}&page={page}")]
    Task<IEnumerable<CommitResponse>> GetCommits(string owner, string repo, int pageSize, int page);
}