using aspnet5ng2seed.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet5ng2seed.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DataController : Controller
    {
        private readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shipment> Get()
        {
            return _context.Shipments
                .Where(x => x.Username == User.Identity.Name)
                .ToList();
        }
    }
}
