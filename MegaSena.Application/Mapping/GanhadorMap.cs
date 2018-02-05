using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MegaSena.Domain;
using Erp.Domain.Model;

namespace MegaSena.Infra.Mapping
{
    public class GanhadorMap : EntityTypeConfiguration<Ganhador>
    {
        public GanhadorMap()
        {
            this.HasKey(t => t.IdJGanhador);
            this.Property(t => t.ValorPremio);
            this.HasRequired(t => t.Jogo).WithMany().HasForeignKey(x => x.IdJogo);
        }
    }
}