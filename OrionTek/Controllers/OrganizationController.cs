using Microsoft.AspNetCore.Mvc;
using OrionTek.Data;

namespace OrionTek.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly DataContext _context;

        public OrganizationController(DataContext context)
        {
            _context = context;
        }

        // GET: Clients
        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Organizations);
        }

    }
}
