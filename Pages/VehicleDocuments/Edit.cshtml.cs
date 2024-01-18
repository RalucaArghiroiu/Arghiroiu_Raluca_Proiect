using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Arghiroiu_Raluca_Proiect.Data;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Pages.VehicleDocuments
{
    public class EditModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public EditModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VehicleDocument VehicleDocument { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VehicleDocument == null)
            {
                return NotFound();
            }

            var vehicledocument =  await _context.VehicleDocument.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicledocument == null)
            {
                return NotFound();
            }
            VehicleDocument = vehicledocument;
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Plate");

            List<SelectListItem> statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Active", Text = "Active" },
                new SelectListItem { Value = "Expired", Text = "Expired" }
            };

            ViewData["Status"] = new SelectList(statusList, "Value", "Text");

            List<SelectListItem> typeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Vignette", Text = "Vignette" },
                new SelectListItem { Value = "Insurance", Text = "Insurance" },
                new SelectListItem { Value = "Roadworthiness", Text = "Roadworthiness" }
            };

            ViewData["Type"] = new SelectList(typeList, "Value", "Text");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VehicleDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDocumentExists(VehicleDocument.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VehicleDocumentExists(int id)
        {
          return (_context.VehicleDocument?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
