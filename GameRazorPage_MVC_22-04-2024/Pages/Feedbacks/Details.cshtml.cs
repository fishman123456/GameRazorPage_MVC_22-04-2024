using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameRazorPage_MVC_22_04_2024.Data;
using GameRazorPage_MVC_22_04_2024.Models;

namespace GameRazorPage_MVC_22_04_2024.Pages.Feedbacks
{
    public class DetailsModel : PageModel
    {
        private readonly GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context _context;

        public DetailsModel(GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context context)
        {
            _context = context;
        }

        public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedback.FirstOrDefaultAsync(m => m.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                Feedback = feedback;
            }
            return Page();
        }
    }
}
