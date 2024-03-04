namespace Common;

public interface IExpressionSpecificationOperator
{
    ExpressionSpecification<TModel> Combine<TModel>(ExpressionSpecification<TModel> left, 
        ExpressionSpecification<TModel> right);
}