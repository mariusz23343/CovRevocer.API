using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
           
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser { DisplayName = "Marek Konrad", UserName = "marek23343", Email = "marek@test.com" },
                    new AppUser { DisplayName = "Rehabilitant Jan Kowalski", UserName = "jankowalski", Email = "kowalski@test.com" }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                };
            }
            if (context.Posts.Any())
                return;

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Leczenie Podstawowe",
                    Content = "Leczenie " +
                    "podstawowe jest bardzo ważne w przypadku chorych na covid. Lorem ipsum " +
                    "dolor sit amet, consectetur adipiscing elit. Nam in neque ac sapien" +
                    " euismod sagittis. Nulla eget tristique justo, eu malesuada nibh." +
                    " Sed imperdiet leo felis, eget tempor velit egestas vitae." +
                    " Suspendisse nec arcu eget libero mattis elementum." +
                    " Aenean egestas urna sed augue ultricies pellentesque." +
                    " Curabitur et ullamcorper nisl, vitae.",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    IsPublished = true,
                    Summary = "Podstawowe informacje",
                    UpdatedAt = DateTime.Now,
                },

                new Post
                {
                    Title = "Leczenie Zaawansowane",
                    Content = "Leczenie " +
                    "zaawansowane jest bardzo ważne w przypadku chorych na covid. Lorem ipsum " +
                    "dolor sit amet, consectetur adipiscing elit. Nam in neque ac sapien" +
                    " euismod sagittis. Nulla eget tristique justo, eu malesuada nibh." +
                    " Sed imperdiet leo felis, eget tempor velit egestas vitae." +
                    " Suspendisse nec arcu eget libero mattis elementum." +
                    " Aenean egestas urna sed augue ultricies pellentesque." +
                    " Curabitur et ullamcorper nisl, vitae.",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    IsPublished = true,
                    Summary = "Podstawowe informacje",
                    UpdatedAt = DateTime.Now,
                },
                new Post
                {
                    Title = "Rekonwalescencja",
                    Content = "Rekonwalescencja  " +
                    "Rekonwalescencja w przypadku chorych na covid. Lorem ipsum " +
                    "dolor sit amet, consectetur adipiscing elit. Nam in neque ac sapien" +
                    " euismod sagittis. Nulla eget tristique justo, eu malesuada nibh." +
                    " Sed imperdiet leo felis, eget tempor velit egestas vitae." +
                    " Suspendisse nec arcu eget libero mattis elementum." +
                    " Aenean egestas urna sed augue ultricies pellentesque." +
                    " Curabitur et ullamcorper nisl, vitae.",
                    CreatedAt = DateTime.Now,
                    PublishedAt = DateTime.Now,
                    IsPublished = true,
                    Summary = "Podstawowe informacje",
                    UpdatedAt = DateTime.Now,
                }
            };

            await context.Posts.AddRangeAsync(posts);

            await context.SaveChangesAsync();
        }
    }
}
