using Common;
using Repository.LiteDb.Entities;

namespace Repository.LiteDb;

public interface IUserRepository
{
    public IEnumerable<User> GetUsers(ExpressionSpecification<User> expressionSpecification);
}