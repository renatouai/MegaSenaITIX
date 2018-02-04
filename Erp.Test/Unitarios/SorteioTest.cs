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
            var sorteio = new Sorteio("Mega Sena da Virada", TipoJogo.MegaSena);
            Assert.IsNotNull(sorteio);
        }

        [TestMethod]
        public void Deve_Retornar_Sorteio_MegaSena_SeisNumeros()
        {
            var list = new List<int>();

            var sorteio = new Sorteio("Mega Sena da Virada", TipoJogo.MegaSena);
            list = sorteio.MegaSena();
            int i = list.Count();

            Assert.AreEqual(i, 6);
        }

        [TestMethod]
        public void Deve_Retornar_Acertadores_MegaSena_Quadra_Quina()
        {
            var sorteio = new Sorteio("Mega Sena da Virada", TipoJogo.MegaSena);
            var jogos = new List<Jogo>();

            for (int i = 0; i <= 100; i++){
                jogos.Add(new Jogo(sorteio, sorteio.MegaSena(), SituacaoJogo.Aposta, new List<Jogador>() { new Jogador("Jogador " + i, "05982100676") }));
            }

            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 55 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quadra 1 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 30 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quadra 2 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 32 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quadra 3 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 1, 2, 3, 4, 5, 41 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quadra 4 ", "05982100676") }));

            jogos.Add(new Jogo(sorteio, new List<int>() { 1,2,3,4,5,10 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quina 1 ", "05982100676") }));
            jogos.Add(new Jogo(sorteio, new List<int>() { 20, 2, 3, 4, 5, 6 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Ganhador Quina 2 ", "05982100676") }));

            jogos.Add(new Jogo(sorteio, new List<int>() { 1,2,3,4,5,6 }, SituacaoJogo.Aposta, new List<Jogador>() { new Jogador(" Augusto Nunes Ganhador Sena ", "05982100676") }));

            sorteio.SetJogos(jogos);

            var ganhadores = sorteio.SorteioMegaSena(new List<int>() { 1,2,3,4,5,6 });

            Assert.IsNotNull(ganhadores);

        }

    }
}
