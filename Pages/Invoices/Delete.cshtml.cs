﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Arghiroiu_Raluca_Proiect.Data;
using Arghiroiu_Raluca_Proiect.Models;

namespace Arghiroiu_Raluca_Proiect.Pages.Invoices
{
    public class DeleteModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public DeleteModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
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

            var invoice = await _context.Invoice
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }
            else 
            {
                Invoice = invoice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice != null)
            {
                Invoice = invoice;
                _context.Invoice.Remove(Invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}