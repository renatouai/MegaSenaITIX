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
        public string NomeSorteio { get;  set; }

        public List<int> Numeros { get;  set; }
    }
}