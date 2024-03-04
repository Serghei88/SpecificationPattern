using System.Linq.Expressions;

namespace Common;

public class DynamicExpressionSpecification<T>(Expression<Func<T, bool>> expression)
    : ExpressionSpecification<T>(expression);