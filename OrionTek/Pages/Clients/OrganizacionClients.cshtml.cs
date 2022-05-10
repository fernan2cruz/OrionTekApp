using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrionTek.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Pages.Clients
{
    public class OrganizacionClientsModel : PageModel
    {

        private readonly OrionTek.Data.DataContext _context;

        public OrganizacionClientsModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Organization Organization { get; set; }

        public IList<Client> Clients { get; set; }

        public async Task OnGetClientsAsync(Guid? guid)
        {
            if (guid == null)
            {
                 NotFound();
            }
            Organization = await _context.Organizations.Include(w=> w.Clients).ThenInclude(ti => ti.Addresses).Where(w=> w.Id == guid).FirstOrDefaultAsync();
            Clients = Organization.Clients;
        }
    }
}
