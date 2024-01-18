using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Arghiroiu_Raluca_Proiect.Data;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Pages.Fleets
{
    public class DeleteModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public DeleteModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fleet Fleet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fleet == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleet
                .Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fleet == null)
            {
                return NotFound();
            }
            else 
            {
                Fleet = fleet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fleet == null)
            {
                return NotFound();
            }
            var fleet = await _context.Fleet.FindAsync(id);

            if (fleet != null)
            {
                Fleet = fleet;
                _context.Fleet.Remove(Fleet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
