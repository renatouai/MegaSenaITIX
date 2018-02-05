using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erp.Api.Model
{
    public class JogoModel
    {
        public int IdJogo { get;  set; }
        public DateTime Data { get;  set; }
        public int IdSorteio { get;  set; }
        public string Situacao { get; set; }
        public string NomeSorteio { get; set; }
        public string Player { get; set; }
        public string Dezenas { get; set; }
        public string TipoPremio { get; set; }
        public decimal ValorPremio { get; set; }
        public List<int> Numeros { get;  set; }
        public List<JogadorModel> Jogadores { get; set; }
    }
}