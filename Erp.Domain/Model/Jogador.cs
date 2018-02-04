using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain
{
    public class Jogador
    {
        public int IdJogador { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        public virtual ICollection<Jogo> Jogos { get; private set; }  // em caso de bolão

        public Jogador() { }

        public Jogador(string nome,string cpf)
        {
            SetNome(nome);
            SetCpf(cpf);
            // quando a classe e muito grande costumo criar uma validate no final
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("O Campo nome é obrigatório");
            else
               this.Nome = nome;
        }

        public void SetCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new Exception("O campo CPF é obrigatório "); 
                // faço a validação na interface com usuário, e a validação no dominio e no mapeamento isrequired()
                // essa validação retorna para minha tela em forma de Exception (API)
            else if (!DomainValidationCommon.IsCpf(cpf))
                throw new Exception("CPF inválido");
            else
                this.CPF = cpf;
        }
    }
}
