using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Arghiroiu_Raluca_Proiect.Data;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Pages.VehicleDocuments
{
    public class CreateModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public CreateModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Plate");

            List<SelectListItem> statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Active", Text = "Active" }
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

        [BindProperty]
        public VehicleDocument VehicleDocument { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.VehicleDocument == null || VehicleDocument == null)
            {
                return Page();
            }

            _context.VehicleDocument.Add(VehicleDocument);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
