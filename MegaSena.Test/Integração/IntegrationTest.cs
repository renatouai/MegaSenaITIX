using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaSena.Domain;
using Erp.Infra.Services;
using MegaSena.Application;
using Erp.Infra.Base;
using System.Data;
using System.Data.Entity;

namespace Erp.Test.Unitarios
{
    [TestClass]
    public class IntegrationTest
    {
        JogadorService _jogadorService;
        JogoService _jogoService;
        SorteioService _sorteioService;

        ErpContext context;
       
        public IntegrationTest()
        {
            context = new ErpContext();
            _jogadorService = new JogadorService(new UnitOfWork<ErpContext>(context));
            _jogoService = new JogoService(new UnitOfWork<ErpContext>(context));
            _sorteioService = new SorteioService(new UnitOfWork<ErpContext>(context));
        }

        [TestMethod]
        public void Deve_Salvar_100_Jogadores()
        {
            for (var i = 0; i <= 100; i++)
            {
                _jogadorService.SalvarJogador(new Jogador("Jogador " + i, DomainValidationCommon.GerarCpf()));
            }
        }

        [TestMethod]
        public void Deve_Salvar_100_Sorteios()
        {
            for (var i = 1; i <= 100; i++)
            {
                _sorteioService.Salvar(new Sorteio("Sorteio " + i, "MegaSena"));
            }

        }


        [TestMethod]
        public void Deve_Salvar_100_Jogos()
        {
            var sorteio = _sorteioService.ObterSorteio(1);
            var jogadores = new List<Jogador>();
            jogadores.Add(new Jogador("Renato Ayres", "05982100676"));
            var aposta = new List<int>() { 1, 2, 3, 4, 5, 6 };
            for (var i = 1; i <= 100; i++)
            {
                _jogoService.SalvarJogo(new Jogo(sorteio, aposta, "Aposta",jogadores));
            }

        }
    }
}
