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
    public class JogadorService : RepositoryBase<ErpContext>, IJogadorService
    {
        public JogadorService(IUnitOfWork<ErpContext> unit)
            : base(unit)
        {
        }

        public Jogador Excluir(Jogador jogador)
        {
            Context.Jogador.Remove(jogador);
            Context.SaveChanges();
            return jogador;
        }
        
        public ICollection<Jogador> ListarJogadores()
        {
            return Context.Jogador.ToList();
        }

        public Jogador ObterJogadorPorId(int id)
        {
            return Context.Jogador.Find(id);
        }

        public void SalvarJogador(Jogador jogador)
        {
            if (jogador.IdJogador > 0)
            {
                Context.Entry(jogador).State = EntityState.Modified;
            }
            else
            {
                Context.Jogador.Add(jogador);
            }
            Context.SaveChanges();
        }
    }
}