using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrionTek.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Pages.Clients
{
    public class CreateClientInOrganizationModel : PageModel
    {

        private readonly OrionTek.Data.DataContext _context;

        public CreateClientInOrganizationModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }
        public Organization Organization { get; set; }
        public IActionResult OnGet(Guid? guid)
        {
            if (guid == null)
            {
                return NotFound();
            }
            Organization = _context.Organizations.Include(i => i.Clients).Where(w=> w.Id == guid).FirstOrDefault(); 
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }
       

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Guid? guid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var clientName = Client.Name;
            Organization = _context.Organizations.Include(i => i.Clients).Where(w => w.Id == guid).FirstOrDefault();
            Organization.Clients.Add(Client);
            _context.Organizations.Update(Organization);            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
