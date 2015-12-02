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
    //[Authorize]
    public class DataController : Controller
    {
        public IEnumerable<Shipment> Get()
        {
            return new List<Shipment>
            {
                new Shipment {
                    Id = 1,
                    Origin = "Sweden, Norrköping",
                    Destination = "Oslo, Norway",
                    ShippedDate = DateTime.UtcNow.AddDays(-1.4)
                },
                new Shipment {
                    Id = 2,
                    Origin = "Sweden, Stockholm",
                    Destination = "Sweden, Gothenburg",
                    ShippedDate = DateTime.UtcNow
                }
            };
        }
    }
}
