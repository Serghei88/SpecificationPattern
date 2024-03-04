using Repository.LiteDb.Entities;

namespace Common.Specifications;

public class YoungerThanSpecification(int threshold) : 
    ExpressionSpecification<User>(u => u.Age < threshold);