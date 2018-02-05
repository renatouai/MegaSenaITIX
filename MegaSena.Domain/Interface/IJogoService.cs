using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain.Interface
{
    public interface IJogoService
    {
        void SalvarJogo(Jogo jogo);
        Jogo ObterJogo(int id);
        Jogo Excluir(Jogo jogo);
        ICollection<Jogo> ListarJogos();
    }
}
