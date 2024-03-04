using Common;
using Microsoft.EntityFrameworkCore;
using Repository.LiteDb.Entities;

namespace Repository.LiteDb;

public class UserRepository: IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<User> GetUsers(ExpressionSpecification<User> expressionSpecification)
    {
        var users = _dataContext.Users
                .Where(expressionSpecification.Expression)
                .TagWith("User Repository Fetch User according to Specification")
                .ToList();

        return users;
    }
}