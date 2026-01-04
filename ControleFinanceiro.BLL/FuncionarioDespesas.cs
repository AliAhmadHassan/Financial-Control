using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class FuncionarioDespesas
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.FuncionarioDespesas> Select()
        {
            return new DAL.FuncionarioDespesas().Select();
        }

        public DTO.FuncionarioDespesas SelectPelaIdControleAcesso(int Id)
        {
            return new DAL.FuncionarioDespesas().SelectPelaIdControleAcesso(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.FuncionarioDespesas Entidade)
        {
            new DAL.FuncionarioDespesas().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.FuncionarioDespesas Entidade)
        {
            new DAL.FuncionarioDespesas().Cadastro(Entidade);
        }
    }
}
