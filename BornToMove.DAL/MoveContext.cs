using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveContext : DbContext {
        public DbSet<Move> Move { get; set;}
        public DbSet<MoveRating> MoveRating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BornToMove;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(builder);
        }

      

    }
}
