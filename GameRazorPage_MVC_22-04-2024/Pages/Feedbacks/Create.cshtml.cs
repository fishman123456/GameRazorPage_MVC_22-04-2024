using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameRazorPage_MVC_22_04_2024.Data;
using GameRazorPage_MVC_22_04_2024.Models;

namespace GameRazorPage_MVC_22_04_2024.Pages.Feedbacks
{
    public class CreateModel : PageModel
    {
        private readonly GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context _context;

        public CreateModel(GameRazorPage_MVC_22_04_2024.Data.GameRazorPage_MVC_22_04_2024Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["VideoGameId"] = new SelectList(_context.VideoGame, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Feedback.Add(Feedback);
            Feedback.LastUpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
