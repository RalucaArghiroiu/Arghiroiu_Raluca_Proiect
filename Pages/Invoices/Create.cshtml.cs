using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Arghiroiu_Raluca_Proiect.Data;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Pages.Invoices
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");

            List<SelectListItem> currencyList = new List<SelectListItem>
            {
                new SelectListItem { Value = "RON", Text = "RON" },
                new SelectListItem { Value = "EUR", Text = "EUR" }
            };

            ViewData["Currency"] = new SelectList(currencyList, "Value", "Text");

            List<SelectListItem> statusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Issued", Text = "Issued" },
                new SelectListItem { Value = "Paid", Text = "Paid" },
                new SelectListItem { Value = "Overdue", Text = "Overdue" }

            };

            ViewData["Status"] = new SelectList(statusList, "Value", "Text");

            return Page();
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Invoice == null || Invoice == null)
            {
                return Page();
            }

            _context.Invoice.Add(Invoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
