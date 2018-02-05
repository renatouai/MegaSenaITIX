using MegaSena.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MegaSena.Infra.Mapping
{
    public class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            this.HasKey(t => t.IdJogo);

            this.Property(t => t.Data).IsRequired();
            this.Property(t => t.Situacao).IsRequired();
         
            this.HasRequired(t => t.Sorteio)
                .WithMany()
                .HasForeignKey(x=>x.IdSorteio);

           
        }
    }
}