using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrionTek.Data;
using OrionTek.Entities;

namespace OrionTek.Pages.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly OrionTek.Data.DataContext _context;

        public IndexModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Organization> Organization { get;set; }        
        public async Task OnGetAsync()
        {
            Organization = await _context.Organizations.Include(i => i.Clients).ToListAsync();
            
        }
    }
}
