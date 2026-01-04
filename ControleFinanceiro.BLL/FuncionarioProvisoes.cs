using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class FuncionarioProvisoes
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.FuncionarioProvisoes> Select()
        {
            return new DAL.FuncionarioProvisoes().Select();
        }

        public DTO.FuncionarioProvisoes SelectPelaIdControleAcesso(int Id)
        {
            return new DAL.FuncionarioProvisoes().SelectPelaIdControleAcesso(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.FuncionarioProvisoes Entidade)
        {
            new DAL.FuncionarioProvisoes().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.FuncionarioProvisoes Entidade)
        {
            new DAL.FuncionarioProvisoes().Cadastro(Entidade);
        }
    }
}
