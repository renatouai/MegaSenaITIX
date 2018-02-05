using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MegaSena.Domain;

namespace MegaSena.Infra.Mapping
{
    public class SorteioMap : EntityTypeConfiguration<Sorteio>
    {
        public SorteioMap()
        {
            this.HasKey(t => t.IdSorteio);

            this.Property(t => t.DataCriacao).IsRequired();
            this.Property(t => t.DataSorteio).IsRequired();

            this.Property(t => t.Tipo).IsRequired();
            this.Property(t => t.Situacao).IsRequired();

            this.HasMany(x => x.Jogos);
            this.HasMany(x => x.Ganhadores);

        }
    }
}