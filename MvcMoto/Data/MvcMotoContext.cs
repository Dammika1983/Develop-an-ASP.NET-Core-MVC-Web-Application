using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMoto.Models;

namespace MvcMoto.Data
{
    public class MvcMotoContext : DbContext
    {
        public MvcMotoContext (DbContextOptions<MvcMotoContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMoto.Models.Moto> Moto { get; set; } = default!;
    }
}
