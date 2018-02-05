using Erp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erp.Api.Model
{
    public class GanhadorModel
    {
        public int IdJGanhador { get;  set; }
        public int IdJogo { get;  set; }
        public string NomeGanhador { get;  set; }
        public string TipoPremio { get; set; }
        public List<int> Numeros { get; set; }

        public int Tipo { get;  set; }
        public decimal ValorPremio { get;  set; }
    }
}