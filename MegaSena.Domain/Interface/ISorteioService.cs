using System.Collections.Generic;

namespace MegaSena.Domain.Interface
{
    public interface ISorteioService
    {
        Sorteio Salvar(Sorteio sorteio);
        Sorteio ObterSorteioPorId(int idsorteio);
        ICollection<Sorteio> ListarSorteios();
        ICollection<Jogador> ListarGanhadores(int idsorteio);
    }
}
