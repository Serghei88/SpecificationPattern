using System.Linq.Expressions;

namespace Common;

internal class ExpressionSpecificationAndOperator
{
    // https://stackoverflow.com/questions/457316/combining-two-expressions-expressionfunct-bool
    public static ExpressionSpecification<TModel> Combine<TModel>(ExpressionSpecification<TModel> left, ExpressionSpecification<TModel> right)
    {
        Expression<Func<TModel, bool>> resultExpression;
        ParameterExpression param = left.Expression.Parameters[0];
        if (ReferenceEquals(param, right.Expression.Parameters[0]))
        {
            resultExpression = Expression.Lambda<Func<TModel, bool>>(
                Expression.AndAlso(left.Expression.Body, right.Expression.Body), param);
        }
        else
        {
            resultExpression = Expression.Lambda<Func<TModel, bool>>(
                Expression.AndAlso(
                    left.Expression.Body,
                    Expression.Invoke(right.Expression, param)), param);
        }

        var combinedSpecification = new ExpressionSpecification<TModel>(resultExpression);
        return combinedSpecification;
    }
}

public static class ExpressionSpecificationAndOperatorExtension
{
    public static ExpressionSpecification<T> And<T>(this ExpressionSpecification<T> specificationLeft, ExpressionSpecification<T> specificationRight)
    {
        ExpressionSpecification<T> expressionSpecification = ExpressionSpecificationAndOperator.Combine(specificationLeft, specificationRight);
        return expressionSpecification;
    }
}