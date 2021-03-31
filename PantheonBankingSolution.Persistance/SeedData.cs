using PantheonBankingSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantheonBankingSolution.Persistance
{
    public class SeedData
    {
        public static async Task SeedDataInitialize(DataContext context)
        {
            if (context.Customers.Any())
            {
                var users = new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        CustomerFullName = "Sam",
                        UserName = "sam",
                    },
                    new Customer
                    {
                        Id = 2,
                        CustomerFullName = "Sam",
                        UserName = "sam",
                    },
                    new Customer
                    {
                        Id = 3,
                        CustomerFullName = "Tom",
                        UserName = "tom",
                    },
                };
                await context.AddRangeAsync(users);

                var accounts = new List<Account>
                {
                    new Account
                    {
                        AccountNumber = 101,
                        CurrentBalance = 5000,
                        Customer = new Customer
                                    {
                                        Id = 1,
                                        CustomerFullName = "Sam",
                                        UserName = "sam",
                                    }
                    },
                    new Account
                    {
                        AccountNumber = 102,
                        CurrentBalance = 6000,
                        Customer = new Customer
                                    {
                                        Id = 2,
                                        CustomerFullName = "Sam",
                                        UserName = "sam",
                                    }
                    },
                    new Account
                    {
                        AccountNumber = 103,
                        CurrentBalance = 7000,
                        Customer = new Customer
                                    {
                                        Id = 3,
                                        CustomerFullName = "Sam",
                                        UserName = "sam",
                                    }
                    },
                };

            }
            await context.SaveChangesAsync();

        }
    }
}