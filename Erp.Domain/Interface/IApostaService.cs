using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain.Interface
{
    public interface IApostaService
    {

        ICollection<Jogo> MegaSena(Jogo jogo);
        ICollection<Jogo> MegaSena(Sorteio sorteio, Jogador jogador);
        ICollection<Jogo> LotoMania(Jogo jogo);


    }
}
