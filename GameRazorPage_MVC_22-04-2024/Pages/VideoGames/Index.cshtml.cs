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

        [BindProperty(SupportsGet = true)]
        public string? SearchRate { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        // список игр, выводим на странице, берем из базы
        public IList<VideoGame> VideoGame { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // добавляем функцию поиска
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.VideoGame
                                            orderby m.Title,m.Description
                                            select m.Title;

            var movies = from m in _context.VideoGame
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString) || s.Description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Title == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            VideoGame = await movies.ToListAsync();
            // выводим список из базы
            //VideoGame = await _context.VideoGame.ToListAsync();
        }
    }
}
