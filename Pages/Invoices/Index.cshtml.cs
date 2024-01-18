using System;
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
    public class IndexModel : PageModel
    {
        private readonly Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext _context;

        public IndexModel(Arghiroiu_Raluca_Proiect.Data.Arghiroiu_Raluca_ProiectContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoice != null)
            {
                Invoice = await _context.Invoice
                .Include(i => i.User).ToListAsync();
            }
        }
    }
}
