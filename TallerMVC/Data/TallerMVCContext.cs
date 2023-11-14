using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerMVC.Models;

namespace TallerMVC.Data
{
    public class TallerMVCContext : DbContext
    {
        public TallerMVCContext (DbContextOptions<TallerMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TallerMVC.Models.Taller> Taller { get; set; } = default!;
    }
}
