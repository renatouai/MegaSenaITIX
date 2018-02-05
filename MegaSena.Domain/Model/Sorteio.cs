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
        public int IdSorteio { get; set; }
        public string Nome { get; private set; } // exemplo Sorteio Mega Sena da Virada 
        public DateTime DataCriacao { get; private set; }
        public DateTime DataSorteio { get; private set; }
        
        public string Tipo { get; private set; }

        public string Situacao { get; private set; }
        public ICollection<Jogo> Jogos { get; private set; }
        public ICollection<Ganhador> Ganhadores { get; private set; }

        public int NumeroGanhadores { get; private set; }
        
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
                    listNumeros.Add(n);
                x++;
            }
            return listNumeros;
        }

        public List<Ganhador> SorteioMegaSena(List<int> numerosSorteados)
        {
            var sortudos = new List<Ganhador>();

            if (numerosSorteados.Count > 6)
                throw new Exception("Números sorteados inválidos");

            // obtem os jogos
            int nacertos = 0;
            foreach(var item in this.Jogos)
            {
               nacertos = item.Numeros.Intersect(numerosSorteados).Count();
               if(nacertos==6)
                    sortudos.Add(new Ganhador(item, "Mega", 1000)); // valor do prêmio pode ser calculado
                else if(nacertos==5)
                    sortudos.Add(new Ganhador(item, "Quina", 1000));
                else if(nacertos==4)
                    sortudos.Add(new Ganhador(item, "Quadra", 1000));
            }

            this.NumeroGanhadores = sortudos.Count(); // Atualiza o numero de ganhadores
            this.Situacao = "Sorteado"; // Atualiza situação do Sorteio
            this.Ganhadores = sortudos;

            return sortudos;
        }
    }
}