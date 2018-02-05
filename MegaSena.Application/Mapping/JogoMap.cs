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
            this.Property(t => t.Dezenas).IsRequired();

            this.HasRequired(t => t.Sorteio)
                .WithMany(t=>t.Jogos)
                .HasForeignKey(x => x.IdSorteio);

            this.HasMany<Jogador>(s => s.Jogadores)
            .WithMany(s => s.Jogos)
            .Map(cs =>
            {
                cs.MapLeftKey("IdJogo");
                cs.MapRightKey("IdJogador");
                cs.ToTable("JogadorJogo");
            });


        }
    }
}