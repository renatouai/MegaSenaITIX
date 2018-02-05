using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MegaSena.Domain;

namespace Erp.Test.Unitarios
{
    [TestClass]
    public class JogadorTest
    {

        [TestMethod]
        public void Deve_Criar_Um_Jogador_Com_Cpf_Valida()
        {
            var jogador = new Jogador("Renato Ayres de Oliveira", "05982100676");
            Assert.IsNotNull(jogador);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "CPF inválido")]
        public void Deve_Validar_Um_Jogador_Com_Cpf_Invalido()
        {
            var jogador = new Jogador("Renato Ayres", "99999999");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Deve_Validar_Um_Jogador_Sem_Nome()
        {
            var jogador = new Jogador(null, "99999999");
            Assert.Fail();
        }
    }
}
