using Erp.Domain.Model;
using MegaSena.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erp.Api.Model
{
    public class SorteioModel
    {
        public int IdSorteio { get;  set; }
        public string Nome { get;  set; } // exemplo Sorteio Mega Sena da Virada 
        public DateTime DataCriacao { get;  set; }
        public DateTime DataSorteio { get;  set; }
        public TipoJogo Tipo { get;  set; }

        public string Situacao { get;  set; }
        public ICollection<JogoModel> Jogos { get;  set; }
        public ICollection<GanhadorModel> Ganhadores { get;  set; }

        public int NumeroGanhadores { get; set; }
    }
}