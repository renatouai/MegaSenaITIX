using System.Collections.Generic;

namespace MegaSena.Domain.Interface
{
    public interface ISorteioService
    {
        void Salvar(Sorteio sorteio);
        Sorteio ObterSorteio(int idsorteio);
        void Excluir(Sorteio sorteio);
        ICollection<Sorteio> ListarSorteios();

        void RealizarSorteioMegaSena(int idsorteio);

        //TODO: Realizar Sorteio LotoMania

    }
}
