using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace aspnet5ng2seed.Models
{
    public class Seeder
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Seeder(
            AppDbContext context, 
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Users.Any())
            {
                for (int i = 0; i < 2; i++)
                {
                    var user = new IdentityUser
                    {
                        UserName = $"test{i}",
                        Email = $"test{i}@tester.com"
                    };

                    await _userManager.CreateAsync(user, "123Qwerty!");
                }
            }

            if (!_context.Shipments.Any())
            {
                var shipments = new List<Shipment>
                {
                    new Shipment
                    {
                        Origin = "Sweden, Norrköping",
                        Destination = "Oslo, Norway",
                        ShippedDate = DateTime.UtcNow.AddDays(-1.4),
                        Username = "test0"
                    },
                    new Shipment
                    {
                        Origin = "Sweden, Stockholm",
                        Destination = "Sweden, Gothenburg",
                        ShippedDate = DateTime.UtcNow,
                        Username = "test1"
                    }
                };

                _context.Shipments.AddRange(shipments);
                await _context.SaveChangesAsync();
            }
        }
    }
}
