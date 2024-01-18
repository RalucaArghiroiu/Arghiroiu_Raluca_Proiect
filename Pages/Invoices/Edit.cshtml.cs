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

namespace Arghiroiu_Raluca_Proiect.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public EditModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice =  await _context.Invoice.FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            Invoice = invoice;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.Id))
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

        private bool InvoiceExists(int id)
        {
          return (_context.Invoice?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
