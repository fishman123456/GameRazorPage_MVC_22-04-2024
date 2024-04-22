using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameRazorPage_MVC_22_04_2024.Data;
using GameRazorPage_MVC_22_04_2024.Models;

namespace GameRazorPage_MVC_22_04_2024.Pages.VideoGames
{
    public class DetailsModel : PageModel
    {
        private readonly GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context _context;

        public DetailsModel(GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context context)
        {
            _context = context;
        }

        public VideoGame VideoGame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videogame = await _context.VideoGame.FirstOrDefaultAsync(m => m.Id == id);
            if (videogame == null)
            {
                return NotFound();
            }
            else
            {
                VideoGame = videogame;
            }
            return Page();
        }
    }
}
