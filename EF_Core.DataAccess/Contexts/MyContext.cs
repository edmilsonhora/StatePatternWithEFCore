using EF_Core.DataAccess.Mappings;
using EF_Core.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DataAccess.Contexts
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Directory.GetCurrentDirectory();

            optionsBuilder.UseSqlite($"Data Source=c:\\teste\\dbTeste.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new AbstractOrcamentoStatusMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Orcamento>  Orcamentos { get; set; }
    }
}
