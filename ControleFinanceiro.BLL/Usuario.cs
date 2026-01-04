using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Usuario
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Usuario> Select()
        {
            return new DAL.Usuario().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Usuario SelectPelaPK(int Id)
        {
            return new DAL.Usuario().SelectPelaPK(Id);
        }

        public List<DTO.Usuario> SelectPelaCarteira(int Id)
        {
            return new DAL.Usuario().SelectPelaCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Usuario Entidade)
        {
            new DAL.Usuario().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Usuario Entidade)
        {
            new DAL.Usuario().Cadastro(Entidade);
        }

        public DTO.Usuario Logar(string Login, string Senha)
        {
            DTO.Usuario dtoLogin = new DAL.Usuario().Logar(Login, Senha);

            if (dtoLogin == null)
                throw new Exception("Usuário e/ou Senha inválidos!");
            else
            {
                if (!dtoLogin.Ativo)
                    throw new Exception("Usuário inativado no Controle RH!");
                else
                {
                    return new DAL.Usuario().Logar(Login, Senha);
                }
            }
        }
    }
}
