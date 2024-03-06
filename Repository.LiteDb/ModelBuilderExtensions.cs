using Microsoft.EntityFrameworkCore;
using Repository.LiteDb.Entities;

namespace Repository.LiteDb;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Name = "User1",
                Age = 3
            },
            new User()
            {
                Id = 2,
                Name = "User2",
                Age = 7
            },
            new User()
            {
                Id = 3,
                Name = "User3",
                Age = 15
            },
            new User()
            {
                Id = 4,
                Name = "User4",
                Age = 18
            },
            new User()
            {
                Id = 5,
                Name = "User5",
                Age = 22
            },
            new User()
            {
                Id = 6,
                Name = "User6",
                Age = 35
            }
        );
        
    }
}