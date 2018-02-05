using Erp.Infra.Base;
using MegaSena.Application;
using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Erp.Infra.Services
{
    public class SorteioService : RepositoryBase<ErpContext>, ISorteioService
    {
        public SorteioService(IUnitOfWork<ErpContext> unit)
            : base(unit)
        {
        }

        public void Excluir(Sorteio sorteio)
        {
            Context.Sorteio.Remove(sorteio);
            Context.SaveChanges();
        }

        #region [EmMemoria]
        //public ICollection<Jogador> ListarGanhadores(int idsorteio)
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Sorteio> ListarSorteios()
        //{
        //    var listasorteio = new List<Sorteio>();

        //    Sorteio _sorteio;
        //    List<Jogo> _jogos;
        //    List<Jogador> _jogador;

        //    for (int x = 1; x <= 50; x++)
        //    {
        //        _sorteio = new Sorteio("Mega Sena Sorteio" + x, TipoJogo.MegaSena);
        //        _sorteio.IdSorteio = x;
        //        _jogos = new List<Jogo>();
        //        for (int y = 1; y <= 20; y++)
        //        {
        //            _jogador = new List<Jogador>() { new Jogador("Jogador " + y, "05982100676") };
        //            _jogos.Add(new Jogo(_sorteio, _sorteio.MegaSena(), SituacaoJogo.Aposta, _jogador));
        //        }
        //        _sorteio.SetJogos(_jogos);
        //        _sorteio.SorteioMegaSena(_sorteio.MegaSena());
        //        listasorteio.Add(_sorteio);
        //    }
        //    return listasorteio;
        //}

        //public Sorteio ObterSorteioPorId(int idsorteio)
        //{
        //    throw new NotImplementedException();
        //}

        //public Sorteio Salvar(Sorteio sorteio)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        public ICollection<Sorteio> ListarSorteios()
        {
            return Context.Sorteio.Include(x => x.Jogos).Include(x => x.Ganhadores).ToList();
        }

        public Sorteio ObterSorteio(int idsorteio)
        {
            return Context.Sorteio.First(x=>x.IdSorteio==idsorteio);
        }

        public void Salvar(Sorteio sorteio)
        {
            if (sorteio.IdSorteio > 0)
            {
                Context.Entry(sorteio).State = EntityState.Modified;
            }
            else
            {
                Context.Sorteio.Add(sorteio);
            }
            Context.SaveChanges();
        }
    }
}