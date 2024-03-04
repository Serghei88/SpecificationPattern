using Repository.LiteDb.Entities;

namespace Common.Specifications;

public class OlderThanSpecification(int threshold) : 
    ExpressionSpecification<User>(u => u.Age < threshold);
