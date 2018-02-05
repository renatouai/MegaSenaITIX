using Erp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MegaSena.Domain
{
    public class Sorteio
    {
        public int IdSorteio { get; private set; }
        public string Nome { get; private set; } // exemplo Sorteio Mega Sena da Virada 
        public DateTime DataCriacao { get; private set; }
        public DateTime DataSorteio { get; private set; }      
        public string Tipo { get; private set; }
        public string Situacao { get; private set; }
        public ICollection<Jogo> Jogos { get; private set; }
        public int NumeroGanhadores { get; private set; }
        public string DezenasSorteadas { get; private set; }


        public Sorteio() {}

        public Sorteio( string nome,string tipo)
        {
            this.DataCriacao = DateTime.Now;
            this.DataSorteio = DateTime.Now.AddMonths(1);
            this.Situacao = "Ativo"; 

            SetNome(nome);
            SetTipoJogo(tipo);
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O Campo nome é obrigatório ");
            else
                this.Nome = nome;
        }

        public void SetNumeroGanhadores(int n)
        {
            this.NumeroGanhadores = n;
        }

        public void SetDezenasSorteadas(string n)
        {
            this.DezenasSorteadas = n;
        }

        public void SetSituacao(string situacao)
        {
            this.Situacao = situacao;
        }

        public void SetJogos(ICollection<Jogo> jogos)
        {
            this.Jogos = jogos;
        }

        public void SetTipoJogo(string tipo)
        {
            this.Tipo = tipo;
        }

        public List<int> MegaSena()
        {
            int x = 0;
            int n = 0;
            var listNumeros = new List<int>();
            Random random = new Random();
            while (x < 6)
            {
                n = random.Next(1, 60);
                if (!listNumeros.Contains(n))
                {
                    listNumeros.Add(n);
                    x++;
                }
                   
            }
            return listNumeros;
        }

        public List<Jogo> SorteioMegaSena(List<int> numerosSorteados)
        {
            var jogos = new List<Jogo>();

            if (numerosSorteados.Count > 6)
                throw new Exception("Números sorteados inválidos");

            int nacertos = 0;
            foreach(var item in this.Jogos)
            {
               nacertos = item.Numeros.Intersect(numerosSorteados).Count();
                if (nacertos == 6)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Mega");
                    item.SetValorPremio(20000);
                    nacertos++;
                }
                else if (nacertos == 5)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quina");
                    item.SetValorPremio(1000);
                    nacertos++;
                }
                else if (nacertos == 4)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quadra");
                    item.SetValorPremio(10);
                }  
            }
            SetNumeroGanhadores(nacertos); // Atualiza o numero de ganhadores
            SetSituacao("Sorteado"); // Atualiza situação do Sorteio

            return jogos;
        }
    }
}