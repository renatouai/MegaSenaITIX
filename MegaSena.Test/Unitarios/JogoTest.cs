using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaSena.Domain;

namespace Erp.Test.Unitarios
{
    /// <summary>
    /// Descrição resumida para UnitTest1
    /// </summary>
    [TestClass]
    public class JogoTest
    {
        ICollection<Jogador> JogadoresBolao { get; set; }
        List<int> ListNumeros { get; set; }
        Sorteio Sorteio { get; set; }

        public JogoTest()
        {
            this.Sorteio = new Sorteio("Mega Sena Virada", "MegaSena");
                        this.ListNumeros = new List<int>();

            int num = 0;
            int cont = 0;
            Random random = new Random();
            while (cont < 6)
            {
                num = random.Next(1, 60);
                if (!ListNumeros.Contains(num))
                {
                    ListNumeros.Add(num);
                    cont++;
                }   
            }

            // jogadores 
            this.JogadoresBolao = new List<Jogador>();
            JogadoresBolao.Add(new Jogador("Reanto Ayres de Oliveira", "05982100676"));
            JogadoresBolao.Add(new Jogador("Pedro da Silva", "77019211500"));
        }

        [TestMethod]
        public void Deve_Criar_Um_Jogo()
        {
            var jogo = new Jogo(Sorteio, ListNumeros, "Aposta", JogadoresBolao);
            Assert.IsNotNull(jogo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Deve_Validar_Criar_Jogo_NumerosRepetidos()
        {
            var _listanumeros = new List<int>();
            _listanumeros.Add(1);
            _listanumeros.Add(1);
            _listanumeros.Add(1);
            _listanumeros.Add(2);
            _listanumeros.Add(2);
            _listanumeros.Add(2);

            var jogo = new Jogo(Sorteio, _listanumeros, "Aposta", JogadoresBolao);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Deve_Validar_Criar_Jogo_Sem_Numero_Aposta()
        {
            var jogo = new Jogo(Sorteio, null, "Aposta", JogadoresBolao);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Sorteio não definido")]
        public void Deve_Validar_Criar_Jogo_Sem_Sorteio()
        {
            var _listanumeros = new List<int>();
            _listanumeros.Add(1);
            _listanumeros.Add(2);
            _listanumeros.Add(3);
            _listanumeros.Add(4);
            _listanumeros.Add(5);
            _listanumeros.Add(6);

            var jogo = new Jogo(null, _listanumeros, "Aposta", JogadoresBolao);
            Assert.Fail();
        }


        [TestMethod]
        [ExpectedException(typeof(Exception),"Nenhum jogador definido")]
        public void Deve_Validar_Criar_Jogo_Sem_Jogadores()
        {

            var _listanumeros = new List<int>();
            _listanumeros.Add(1);
            _listanumeros.Add(2);
            _listanumeros.Add(3);
            _listanumeros.Add(4);
            _listanumeros.Add(5);
            _listanumeros.Add(6);

            var jogo = new Jogo(Sorteio, null, "Aposta",null);
            Assert.Fail();
        }

    }
}
