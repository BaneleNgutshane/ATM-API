using System;
using Microsoft.EntityFrameworkCore;

namespace vpos.seb.domain.infrastructure.Extensions
{
    /// <summary>
    /// App db seeding extension with fake data.
    /// </summary>
    public static class AppDbSeedingExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Jane", Surname = "Doe" },
                new Customer { Id = 2, Name = "John", Surname = "Smith" },
                new Customer { Id = 3, Name = "Bob", Surname = "Alice" }
                );

            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount { Id = 1, Balance = 600.0m, CustomerId = 1, Name = "Default", Number = "12345678", Pin = "1234" },
                new BankAccount { Id = 2, Balance = 7800.11m, CustomerId = 2, Name = "Default", Number = "800138782", Pin = "5688" },
                new BankAccount { Id = 3, Balance = 4300, CustomerId = 3, Name = "Default", Number = "99061537", Pin = "1587" }
               );
        }
    }
}
