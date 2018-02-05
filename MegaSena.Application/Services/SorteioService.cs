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

        public ICollection<Sorteio> ListarSorteios()
        {
            return Context.Sorteio.Include(x=>x.Jogos).ToList();
        }

        public Sorteio ObterSorteio(int idsorteio)
        {
            return Context.Sorteio.Include(x=>x.Jogos).First(x=>x.IdSorteio==idsorteio);
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

        public void RealizarSorteioMegaSena(int idsorteio)
        {
            var sorteio = Context.Sorteio.Include(x=>x.Jogos).First(x=>x.IdSorteio==idsorteio);

            var jogos = new List<Jogo>();
            var numerosSorteados = sorteio.MegaSena();  /// new List<int>() { 59, 10, 35, 39, 25, 18 }; // sorteio.MegaSena();  //   
            
            // gero numeros do sorteio

            int nacertos = 0;
            int contAcertadores = 0;
            foreach (var item in sorteio.Jogos)
            {

                List<int> res = item.Dezenas.Split(',').Select(Int32.Parse).ToList();
                item.SetNumeros(res);
                nacertos = item.Numeros.Intersect(numerosSorteados).Count();

                if (nacertos == 6)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Mega");
                    item.SetValorPremio(20000);
                    contAcertadores++;
                }
                else if (nacertos == 5)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quina");
                    item.SetValorPremio(1000);
                    contAcertadores++;
                }
                else if (nacertos == 4)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quadra");
                    item.SetValorPremio(10);
                    contAcertadores++;
                }
                else
                {
                    item.SetSituacao("Perdeu");
                    item.SetValorPremio(0);
                }
            }

            sorteio.SetNumeroGanhadores(contAcertadores); // Atualiza o numero de ganhadores
            sorteio.SetSituacao("Sorteado"); // Atualiza situação do Sorteio
            sorteio.SetDezenasSorteadas(string.Join(",", numerosSorteados));


            Context.Entry(sorteio).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}