using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrionTek.Data;
using OrionTek.Entities;

namespace OrionTek.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly OrionTek.Data.DataContext _context;

        public IndexModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; }

        public async Task OnGetAsync()
        {
            Client = await _context.Clients.ToListAsync();
        }
    }
}
