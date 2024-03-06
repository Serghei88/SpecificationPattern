﻿using System.Linq.Expressions;

namespace Common;

public abstract class ExpressionSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; }

    private Func<T, bool> ExpressionFunc { get; }

    protected ExpressionSpecification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public bool IsSatisfied(T obj)
    {
        bool result = ExpressionFunc(obj);
        return result;
    }
}