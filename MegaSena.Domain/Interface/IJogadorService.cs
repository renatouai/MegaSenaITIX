using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain.Interface
{
    public interface IJogadorService
    {
        void SalvarJogador(Jogador jogador);
        Jogador ObterJogadorPorId(int id);
        Jogador Excluir(Jogador jogaodr);
        ICollection<Jogador> ListarJogadores();
    }
}
