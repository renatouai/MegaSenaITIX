using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaSena.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Erp.Test.Unitarios
{
    [TestClass]
    public class SorteioTest
    {
        //[metodo]_[condicao]_[resultadoesperado]

        [TestMethod]
        public void Deve_Criar_um_Sorteio()
        {
            var sorteio = new Sorteio("Mega Sena da Virada", "MegaSena");
            Assert.IsNotNull(sorteio);
        }

        [TestMethod]
        public void Deve_Retornar_Sorteio_MegaSena_SeisNumeros()
        {
            var list = new List<int>();

            var sorteio = new Sorteio("Mega Sena da Virada", "MegaSena");
            list = sorteio.MegaSena();
            int i = list.Count();

            Assert.AreEqual(i, 6);
        }

        [TestMethod]
        public void Deve_Retornar_Acertadores_MegaSena_Quadra_Quina()
        {
            var sorteio = new Sorteio("Mega Sena da Virada","MegaSena");
            var jogos = new List<Jogo>();

            // a probabilidade de sair os números 1,2,3,4,5,6 e muito grande
            for (int i = 0; i <= 100; i++){
                jogos.Add(new Jogo(sorteio, sorteio.MegaSena(), "Aposta", new List<Jogador>() { new Jogador("Jogador " + i, "05982100676") }));
            }
            
            // esses são os ganhadores
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 55 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quadra 1 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 30 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quadra 2 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 32 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quadra 3 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 41 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quadra 4 ", "05982100676") }));

            jogos.Add(new Jogo(sorteio, new List<int>() { 1,2,3,4,5,10 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quina 1 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 20, 2, 3, 4, 5, 6 }, "Aposta", new List<Jogador>() { new Jogador(" Ganhador Quina 2 ", "05982100676") }));

            jogos.Add(new Jogo(sorteio, new List<int>() { 1,2,3,4,5,6 }, "Aposta", new List<Jogador>() { new Jogador(" Augusto Nunes Ganhador Sena ", "05982100676") }));

            sorteio.SetJogos(jogos);

            int ganhadores = sorteio.SorteioMegaSena(new List<int>() { 1,2,3,4,5,6 });

            Assert.AreEqual(7,ganhadores);

        }

    }
}
