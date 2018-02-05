using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace MegaSena.Domain
{
    public class Jogo
    {
       public int IdJogo { get;  set; } 
       public DateTime Data { get; private set; }
       public int IdSorteio { get; private set; }
       public Sorteio Sorteio { get; private set; }
       
       public List<int> Numeros { get; private set; }
       public string Dezenas { get; private set; }

        [ScriptIgnore]
        public SituacaoJogo Situacao { get; private set; }

       public virtual ICollection<Jogador> Jogadores { get; private set; }  // em caso de bolão
       
       public Jogo() {  }

        public Jogo(Sorteio sorteio, List<int> numeros, SituacaoJogo situacao, ICollection<Jogador> jogadores)
        {
            this.Data = DateTime.Now;

            SetSorteio(sorteio);
            SetNumeros(numeros);
            SetJogadores(jogadores);
            SetSituacao(situacao);
        }

        public void SetSituacao(SituacaoJogo situacao)
        {
            this.Situacao = situacao;
        }

        public void SetNumeros(List<int> numeros)
        {
            if (numeros == null)
                throw new Exception("Números da aposta não definidos ");
            else if (!DomainValidationCommon.ValidaNumerosRepetidos(numeros))
                throw new Exception("O jogo possui números repetidos ");
            else
                this.Numeros = numeros;
        }

        public void SetSorteio(Sorteio sorteio)
        {
            if (sorteio == null)
                throw new Exception("Sorteio não definido");
            else
                this.Sorteio = sorteio;
        }

        public void SetJogadores(ICollection<Jogador> jogadores)
        {
            if (jogadores == null)
                throw new Exception("Nenhum jogador definido");
            else
                this.Jogadores = jogadores;
        }

    }
}
