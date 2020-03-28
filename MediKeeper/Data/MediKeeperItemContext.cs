using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediKeeper.Models;

    public class MediKeeperItemContext : DbContext
    {
        public MediKeeperItemContext (DbContextOptions<MediKeeperItemContext> options)
            : base(options)
        {
        }

        public DbSet<MediKeeper.Models.Item> Item { get; set; }
    }
