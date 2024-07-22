using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn_asp_net.Models;
using Microsoft.EntityFrameworkCore;

namespace learn_asp_net.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}