using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearsleePublicHouse.Models
{
    public class GiftCardContext : DbContext
    {

        public GiftCardContext(DbContextOptions<GiftCardContext> options) : base(options)
        {

        }

        public DbSet<Website> Website { get; set; }


        public DbSet<GiftCardCart> GiftCardCart { get; set; }

    }
}
