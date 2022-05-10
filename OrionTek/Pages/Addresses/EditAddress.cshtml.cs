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

namespace OrionTek.Pages.Addresses
{
    public class EditAddressModel : PageModel
    {
        private readonly OrionTek.Data.DataContext _context;

        public EditAddressModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }

        public Client Client { get; set; }
        public Guid AddressId { get; set; } 
        [BindProperty]
        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAddressesAsync(Guid? guid, Guid? id)
        {
            if (guid == null)
            {
                return NotFound();
            }
            Client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == guid);
            AddressId = id.Value;
            Address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(Guid? guid, Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var actualAddress = await _context.Address.FindAsync(id);

            if (actualAddress != null)
            {
                _context.Address.Remove(actualAddress);
                await _context.SaveChangesAsync();
            }

            //Registramos la Nueva Direccion
            Client = await _context.Clients.Include(i=> i.Addresses).FirstOrDefaultAsync(f=> f.Id==guid);
            Client.Addresses.Add(Address);   
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(Address.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Clients/Index");
        }

        private bool AddressExists(Guid id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
