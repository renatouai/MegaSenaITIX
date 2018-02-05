using Erp.Infra.Base;
using MegaSena.Application;
using MegaSena.Domain;
using MegaSena.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Erp.Infra.Services
{
    public class JogoService : RepositoryBase<ErpContext>, IJogoService
    {
        public JogoService(IUnitOfWork<ErpContext> unit)
            : base(unit)
        {
        }

        public Jogo Excluir(Jogo jogo)
        {
            Context.Jogo.Remove(jogo);
            Context.SaveChanges();
            return jogo;
        }

        public ICollection<Jogo> ListarJogos()
        {
            return Context.Jogo.Include(x=>x.Sorteio).ToList();
        }

        public Jogo ObterJogo(int id)
        {
            return Context.Jogo.Include(x=>x.Sorteio).FirstOrDefault(x=>x.IdJogo == id);
        }

        public void SalvarJogo(Jogo jogo)
        {
            if (jogo.IdJogo > 0)
            {
                Context.Entry(jogo).State = EntityState.Modified;
            }
            else
            {
                Context.Jogo.Add(jogo);
            }
            Context.SaveChanges();
        }
    }
}