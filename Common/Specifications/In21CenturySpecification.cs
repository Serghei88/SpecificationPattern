namespace Common.Specifications;

public class In21CenturySpecification : ISpecification<DateTime>
{
    private readonly DateTime _start = new(2001, 01, 01);
    private readonly DateTime _end = new(2101, 01, 01);

    public bool IsSatisfied(DateTime obj)
    {
        bool result = obj >= _start && obj < _end;
        return result;
    }
}