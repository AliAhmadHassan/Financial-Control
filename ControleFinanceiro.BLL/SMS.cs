using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class SMS
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.SMS> Select()
        {
            return new DAL.SMS().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.SMS SelectPelaPK(int Id)
        {
            return new DAL.SMS().SelectPelaPK(Id);
        }

        public List<DTO.SMS> SelectPelaCarteira(int Id)
        {
            return new DAL.SMS().SelectPelaCarteira(Id);
        }

        public List<DTO.SMS> SelectPeloUsuario(int Id)
        {
            return new DAL.SMS().SelectPeloUsuario(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.SMS Entidade)
        {
            new DAL.SMS().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.SMS Entidade)
        {
            new DAL.SMS().Cadastro(Entidade);
        }
    }
}
