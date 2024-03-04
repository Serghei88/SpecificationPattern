using Common.Specifications;
using Repository.LiteDb.Entities;

namespace Common.Extensions;

public static class OlderThanSpecificationExtension
{
    public static bool OlderThan(this User user, int threshold)
    {
        var specification = new OlderThanSpecification(threshold);
        bool result = specification.IsSatisfied(user);
        return result;
    }

    public static IEnumerable<User> OlderThan(this IEnumerable<User> users, int threshold)
    {
        return users.Where(x => x.YoungerThan(threshold));
    }

    public static IQueryable<User> OlderThan(this IQueryable<User> users, int threshold)
    {
        var specification = new OlderThanSpecification(threshold);
        return users.Where(specification.Expression);
    }
}