using EF_Core.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.DataAccess.Mappings
{
    internal class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamentos");
            builder.Property(p => p.Cliente).HasMaxLength(255).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CadastradoPor).HasMaxLength(255).IsRequired();




        }
    }
}
