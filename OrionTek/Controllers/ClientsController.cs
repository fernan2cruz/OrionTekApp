using Microsoft.AspNetCore.Mvc;
using OrionTek.Data;
using System.Collections.Generic;
using System.Linq;

namespace OrionTek.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientsController(DataContext context)
        {
            _context = context;
        }

        // GET: Clients
        [HttpGet]
        public IActionResult GetClients()
        {
            return Ok(_context.Clients);
        }

    }
}
