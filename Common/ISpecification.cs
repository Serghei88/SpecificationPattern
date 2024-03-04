namespace Common;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}