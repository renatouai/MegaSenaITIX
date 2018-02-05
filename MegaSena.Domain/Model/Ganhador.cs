using MegaSena.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erp.Domain.Model
{
    public class Ganhador
    {
        public int IdJGanhador { get; private set; }
        public int IdJogo { get; private set; }
        public Jogo Jogo { get; private set; }
        
        public TipoPremio Tipo { get; private set; }
        public decimal ValorPremio { get; private set; }

        public Ganhador() { }

        public Ganhador(Jogo jogo,TipoPremio tipoPremio,decimal valorPremio)
        {
            this.Jogo = jogo;
            this.Tipo = tipoPremio;
            this.ValorPremio = valorPremio;

            Valida();
        }

        public void Valida()
        {
            if (this.Jogo == null)
                throw new Exception("Jogo não definido");
            if (Tipo == null)
                throw new Exception("Prêmio não definido");
            if (this.ValorPremio == 0)
                throw new Exception("Valor do Prêmio não definido");
        }

    }
}