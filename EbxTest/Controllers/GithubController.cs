using AutoMapper;
using EbxTest.Models;
using EbxTest.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EbxTest.Controllers;

[ApiController]
[Route("api/v1")]
public class GithubController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public GithubController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{owner:required}/{repo:required}/contributors")]
    public async Task<IActionResult> GetContributors(string owner, string repo)
    {
        var query = new ContributorsQuery(owner, repo, 30);
        var response = await _mediator.Send(query);

        return Ok(_mapper.Map<Contributor[]>(response));
    }
}