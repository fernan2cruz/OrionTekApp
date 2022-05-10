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
    public class DetailsModel : PageModel
    {
        private readonly OrionTek.Data.DataContext _context;

        public DetailsModel(OrionTek.Data.DataContext context)
        {
            _context = context;
        }

        public Organization Organization { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organization = await _context.Organizations.FirstOrDefaultAsync(m => m.Id == id);

            if (Organization == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
