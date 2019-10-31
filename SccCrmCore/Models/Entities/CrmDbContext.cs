using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Entities
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Siren> Sirens { get; set; }
        public DbSet<Siret> Sirets { get; set; }
        
    }
}
