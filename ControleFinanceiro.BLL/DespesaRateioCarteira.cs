using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class DespesaRateioCarteira
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.DespesaRateioCarteira> Select()
        {
            return new DAL.DespesaRateioCarteira().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.DespesaRateioCarteira SelectPelaPK(int Id)
        {
            return new DAL.DespesaRateioCarteira().SelectPelaPK(Id);
        }

        public List<DTO.DespesaRateioCarteira> SelectPeloDespesasRatio(int Id)
        {
            return new DAL.DespesaRateioCarteira().SelectPeloDespesasRatio(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(int IdDespesasRateio)
        {
            new DAL.DespesaRateioCarteira().Remover(IdDespesasRateio);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.DespesaRateioCarteira Entidade)
        {
            new DAL.DespesaRateioCarteira().Cadastro(Entidade);
        }
    }
}
