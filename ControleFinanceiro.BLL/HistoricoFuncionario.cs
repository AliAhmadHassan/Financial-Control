using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class HistoricoFuncionario
    {

        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Entidade informada</returns>
        public DTO.HistoricoFuncionario SelectPelaPK(int Id)
        {
            return new DAL.HistoricoFuncionario().SelectPelaPK(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.HistoricoFuncionario Entidade)
        {
            new DAL.HistoricoFuncionario().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.HistoricoFuncionario Entidade)
        {
            new DAL.HistoricoFuncionario().Cadastro(Entidade);
        }

        public List<DTO.HistoricoFuncionario> SelectByDataCadastro(DateTime DataCadastro)
        {
            return new DAL.HistoricoFuncionario().SelectByDataCadastro(DataCadastro);
        }
    }
}
