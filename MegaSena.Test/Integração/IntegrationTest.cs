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
using Erp.Domain.Model;
using System.Linq;
using System.Text.RegularExpressions;

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
        public void Deve_Salvar_5_Jogos()
        {
            var sorteio = _sorteioService.ObterSorteio(1);


            for (var i = 1; i <= 5; i++)
            {
                var jogadores = new List<Jogador>();
                jogadores.Add(new Jogador("Player " + i, "05982100676"));

                var aposta = sorteio.MegaSena();
                _jogoService.SalvarJogo(new Jogo(sorteio, aposta, "Aposta", jogadores));
            }
        }
        
        [TestMethod]
        public void Deve_Realizar_um_Sorteio()
        {
            var sorteio = _sorteioService.ObterSorteio(1);

            var jogos = new List<Jogo>();
            var numerosSorteados = new List<int>(){ 1,2,3,4,5,6 }; // Definir os números vencedores

            int nacertos = 0;
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
                    nacertos++;
                }
                else if (nacertos == 5)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quina");
                    item.SetValorPremio(1000);
                    nacertos++;
                }
                else if (nacertos == 4)
                {
                    item.SetSituacao("Ganhou");
                    item.SetTipoPremio("Quadra");
                    item.SetValorPremio(10);
                }
                else
                {
                    item.SetSituacao("Perdeu");
                    item.SetValorPremio(0);
                }
            }
            sorteio.SetNumeroGanhadores(nacertos); // Atualiza o numero de ganhadores
            sorteio.SetSituacao("Sorteado"); // Atualiza situação do Sorteio

            _sorteioService.Salvar(sorteio);
        }

    }
}
