using Common.Specifications;
using Repository.LiteDb.Entities;

namespace Common.Extensions;


public static class YoungerThanSpecificationExtension
{
    public static bool YoungerThan(this User user, int threshold)
    {
        var specification = new YoungerThanSpecification(threshold);
        bool result = specification.IsSatisfied(user);
        return result;
    }

    public static IEnumerable<User> YoungerThan(this IEnumerable<User> users, int threshold)
    {
        return users.Where(x => x.YoungerThan(threshold));
    }

    public static IQueryable<User> YoungerThan(this IQueryable<User> users, int threshold)
    {
        var specification = new YoungerThanSpecification(threshold);
        return users.Where(specification.Expression);
    }
}