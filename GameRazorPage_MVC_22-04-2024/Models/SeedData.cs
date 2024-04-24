using GameRazorPage_MVC_22_04_2024.Data;
using Microsoft.EntityFrameworkCore;

namespace GameRazorPage_MVC_22_04_2024.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameRazorPage_MVC_22_04_2024Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameRazorPage_MVC_22_04_2024Context>>()))
            {
                if (context == null || context.VideoGame == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.VideoGame.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Title = "When Harry Met Sally",
                        Description = "abpi",
                        Price = 45,
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Rate = 2,
                        CopiesSold = 2
                    },
                    new VideoGame
                    {
                        Title = "Call of dutty",
                        Description = "Стрелялка",
                        Price = 450,
                        ReleaseDate = DateTime.Parse("1962-2-12"),
                        Rate = 212,
                        CopiesSold = 2444
                    },
                    new VideoGame
                    {
                        Title = "Mario",
                        Description = "Dendy",
                        Price = 45,
                        ReleaseDate = DateTime.Parse("1991-1-10"),
                        Rate = 111,
                        CopiesSold = 555555
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
