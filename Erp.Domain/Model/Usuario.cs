using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain
{
    public class Usuario
    {
        public int IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
    }
}
