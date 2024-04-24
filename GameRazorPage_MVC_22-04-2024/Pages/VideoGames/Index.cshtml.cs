using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameRazorPage_MVC_22_04_2024.Data;
using GameRazorPage_MVC_22_04_2024.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameRazorPage_MVC_22_04_2024.Pages.VideoGames
{
    public class IndexModel : PageModel
    {
        private readonly GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context _context;

        public IndexModel(GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context context)
        {
            _context = context;
        }

        // реализация поиска
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        // список игр, выводим на странице, берем из базы
        public IList<VideoGame> VideoGame { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // добавляем функцию описка
            var movies = from m in _context.VideoGame
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            VideoGame = await movies.ToListAsync();


            // выводим список из базы
            VideoGame = await _context.VideoGame.ToListAsync();
        }
    }
}
