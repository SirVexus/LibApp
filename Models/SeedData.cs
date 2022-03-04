using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                    SeedMembershipTypes(context);

                if (!context.Roles.Any())
                    SeedRoles(context);

                if (!context.Customers.Any())
                     SeedCustomers(userManager);

                if (!context.Genre.Any())
                    SeedGenres(context);

                if (!context.Books.Any())
                    SeedBooks(context);

<<<<<<< Updated upstream
                context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay as You Go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quaterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
=======
>>>>>>> Stashed changes
                context.SaveChanges();
            }
        }

        private static void SeedBooks(ApplicationDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    GenreId = 1,
                    Name = "Lord of the Lords",
                    AuthorName = "Jeremy Town",
                    ReleaseDate = DateTime.Parse("11/02/2015"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 2
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Glory",
                    AuthorName = "Jim Beams",
                    ReleaseDate = DateTime.Parse("20/03/2003"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Matrix",
                    AuthorName = "Andy Kolinsky",
                    ReleaseDate = DateTime.Parse("23/02/2010"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Homeless Artis",
                    AuthorName = "Burn Brians",
                    ReleaseDate = DateTime.Parse("20/02/2016"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Cave",
                    AuthorName = "Steven Budovski",
                    ReleaseDate = DateTime.Parse("9/08/2013"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Simpsonh",
                    AuthorName = "Tom Brans",
                    ReleaseDate = DateTime.Parse("12/11/2011"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Boy",
                    AuthorName = "Tom Hans",
                    ReleaseDate = DateTime.Parse("22/01/2011"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Evil Tree",
                    AuthorName = "Johny Cash",
                    ReleaseDate = DateTime.Parse("22/01/2013"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                }
            );
        }

        private static void SeedGenres(ApplicationDbContext context)
        {
            context.Genre.AddRange(
                new Genre
                {
                    Id = 1,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Biography"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Sci - Fi"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Criminal"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Romance"
                }
            );
        }

        private static void SeedCustomers(UserManager<Customer> userManager)
        {
            var hasher = new PasswordHasher<Customer>();

            var customer1 = new Customer
            {
                Name = "Patryk Swidzinski",
                Email = "patrykswidzinski@gmail.com",
                NormalizedEmail = "patrykswidzinski@gmail.com",
                UserName = "patrykswidzinski@gmail.com",
                NormalizedUserName = "patrykswidzinski@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "abcdef123!")
            };

  
            userManager.CreateAsync(customer1).Wait();
            userManager.AddToRoleAsync(customer1, "user").Wait();

            var customer2 = new Customer
            {
                Name = "Miriam Walk",
                Email = "jahoo123@gmail.com",
                NormalizedEmail = "jahoo123@gmail.com",
                UserName = "jahoo123@gmail.com",
                NormalizedUserName = "jahoo123@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "zxydfe12")
            };


            userManager.CreateAsync(customer2).Wait();
            userManager.AddToRoleAsync(customer2, "storemanager").Wait();

            var customer3 = new Customer
            {
                Name = "Tom Hill",
                Email = "hamster1@gmail.com",
                NormalizedEmail = "hamster1@gmail.com",
                UserName = "hamster1@gmail.com",
                NormalizedUserName = "hamster1@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "hamsters1234")
            };


            userManager.CreateAsync(customer3).Wait();
            userManager.AddToRoleAsync(customer3, "owner").Wait();
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddRange(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "StoreManager",
                    NormalizedName = "storemanager"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Owner",
                    NormalizedName = "owner"
                }
            );

            context.SaveChanges();
        }

        private static void SeedMembershipTypes(ApplicationDbContext context)
        {
            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "Pay as You Go",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Monthly",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "Quaterly",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "Yearly",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                }
            );

            context.SaveChanges();
        }
    }
}