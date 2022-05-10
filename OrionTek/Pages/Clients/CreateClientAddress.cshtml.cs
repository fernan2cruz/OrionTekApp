using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTek.Data;
using OrionTek.Entities;

namespace OrionTek.Pages.Clients
{
    public class CreateClientAddressModel : PageModel
    {
        private readonly OrionTek.Data.DataContext _context;

        public CreateClientAddressModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }
        public Client Client { get; set; }  
        public IActionResult OnGet(Guid? guid)
        {
            if (guid == null)            
                return NotFound();
            Client = _context.Clients.Include(i => i.Addresses).Where(w=> w.Id == guid).SingleOrDefault();  

            return Page();
        }

        [BindProperty]
        public Address Address { get; set; }
      
        public async Task<IActionResult> OnPostAsync(Guid? guid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (guid == null)
                return NotFound();

            Address.CreationDate = DateTime.Now;
            Client = _context.Clients.Include(i => i.Addresses).Where(w => w.Id == guid).SingleOrDefault();
            Client.Addresses.Add(Address);  
            _context.Clients.Update(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
