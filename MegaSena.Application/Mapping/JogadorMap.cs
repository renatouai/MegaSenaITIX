using MegaSena.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MegaSena.Infra.Mapping
{
    public class JogadorMap : EntityTypeConfiguration<Jogador>
    {
        public JogadorMap()
        {
            this.HasKey(t => t.IdJogador);
            this.Property(t => t.Nome).IsRequired();
            this.Property(t => t.CPF).IsRequired();
        }
    }
}