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
    internal class AbstractOrcamentoStatusMap : IEntityTypeConfiguration<AbstractOrcamentoState>
    {
        public void Configure(EntityTypeBuilder<AbstractOrcamentoState> builder)
        {
            builder.ToTable("OrcamentoStatusHistorico")
                .HasDiscriminator<int>("OrcamentoStatus")
                .HasValue<Novo>(0)
                .HasValue<EmAprovacao>(1)
                .HasValue<Aprovado>(2)
                .HasValue<Reprovado>(3)
                .HasValue<Cancelado>(4);
        }
    }
}
