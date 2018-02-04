using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Erp.Infra.Services
{
    public class SorteioService : ISorteioService
    {
        public ICollection<Jogador> ListarGanhadores(int idsorteio)
        {
            throw new NotImplementedException();
        }

        public ICollection<Sorteio> ListarSorteios()
        {
            var listasorteio = new List<Sorteio>();

            Sorteio _sorteio;
            List<Jogo> _jogos;
            List<Jogador> _jogador;

            for (int x = 1; x <= 50; x++)
            {
                _sorteio = new Sorteio("Mega Sena Sorteio" + x, TipoJogo.MegaSena);
                _sorteio.IdSorteio = x;
                _jogos = new List<Jogo>();
                for (int y = 1; y <= 20; y++)
                {
                    _jogador = new List<Jogador>() { new Jogador("Jogador " + y, "05982100676") };
                    _jogos.Add(new Jogo(_sorteio, _sorteio.MegaSena(), SituacaoJogo.Aposta, _jogador));
                }
                _sorteio.SetJogos(_jogos);
                _sorteio.SorteioMegaSena(_sorteio.MegaSena());
                listasorteio.Add(_sorteio);
            }
            return listasorteio;
        }

        public Sorteio ObterSorteioPorId(int idsorteio)
        {
            throw new NotImplementedException();
        }

        public Sorteio Salvar(Sorteio sorteio)
        {
            throw new NotImplementedException();
        }
    }
}