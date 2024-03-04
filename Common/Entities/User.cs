namespace Repository.LiteDb.Entities;

public class User
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public int Height { get; private set; }
    public int Age { get; private set; }
}