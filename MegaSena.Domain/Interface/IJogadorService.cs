using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain.Interface
{
    public interface IJogadorService
    {
        Jogador SalvarJogador(Jogador jgoador);
        Jogador ObterJogadorPorId(int id);
        ICollection<Jogador> ListarJogadores();


    }
}
