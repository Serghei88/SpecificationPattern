using System.Net;
using Common;
using Common.Extensions;
using Common.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.LiteDb;
using Repository.LiteDb.Entities;

namespace WebApi.Controllers;

public class UserController: ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IUserRepository _userRepository;

    public UserController(DataContext dataContext, IUserRepository userRepository)
    {
        _dataContext = dataContext;
        _userRepository = userRepository;
    }
    
    [HttpGet("users/in-age-range")]
    public IActionResult InAgeRange([FromQuery] int olderThan, [FromQuery] int youngerThan)
    {
        ExpressionSpecification<User> specification
            = new YoungerThanSpecification(youngerThan)
                .And(new OlderThanSpecification(olderThan));
    
        List<User> users = _userRepository.GetUsers(specification)
            .ToList();

        return StatusCode((int) HttpStatusCode.OK, new {totalCount = users.Count, users});
    }
    
    [HttpGet("users/fetch-with-queryable-extension")]
    public async Task<IActionResult> FetchWithQueryableExtension([FromQuery] int? olderThan, [FromQuery] int? youngerThan)
    {
        IQueryable<User> userModels = _dataContext.Users.AsQueryable();

        if (olderThan.HasValue)
            userModels = userModels.OlderThan(olderThan.Value);

        if (youngerThan.HasValue)
            userModels = userModels.YoungerThan(youngerThan.Value);
    
        List<User> users = await userModels.TagWith("Fetching User via Extension")
            .ToListAsync();

        return StatusCode((int) HttpStatusCode.OK, new {totalCount = users.Count, users});
    }
}