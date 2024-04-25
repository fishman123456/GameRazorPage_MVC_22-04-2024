using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameRazorPage_MVC_22_04_2024.Models;

namespace GameRazorPage_MVC_22_04_2024.Data
{
    public class GameRazorPage_MVC_22_04_2024Context : DbContext
    {
        public GameRazorPage_MVC_22_04_2024Context (DbContextOptions<GameRazorPage_MVC_22_04_2024Context> options)
            : base(options)
        {
        }

        public DbSet<GameRazorPage_MVC_22_04_2024.Models.VideoGame> VideoGame { get; set; } = default!;
        public DbSet<GameRazorPage_MVC_22_04_2024.Models.Feedback> Feedback { get; set; } = default!;
    }
}
