using System.Linq.Expressions;

namespace Common;

public  class ExpressionSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; }

    public ExpressionSpecification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public bool IsSatisfied(T obj)
    {
        bool result = Expression.Compile().Invoke(obj);
        return result;
    }
}