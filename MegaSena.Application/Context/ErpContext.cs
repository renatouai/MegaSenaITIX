using Erp.Domain.Model;
using MegaSena.Domain;
using MegaSena.Infra.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MegaSena.Application
{
    public partial class ErpContext : DbContext
    {
        public DbSet<Sorteio> Sorteio { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        static ErpContext()
        {
            Database.SetInitializer<ErpContext>(null);
        }

        public ErpContext()
            : base("ErpConnect")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new SorteioMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new JogadorMap());
        }
    }
}