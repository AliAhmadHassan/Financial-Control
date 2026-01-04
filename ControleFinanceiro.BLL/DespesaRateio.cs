using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class DespesaRateio
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.DespesaRateio> Select()
        {
            return new DAL.DespesaRateio().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.DespesaRateio SelectPelaPK(int Id)
        {
            return new DAL.DespesaRateio().SelectPelaPK(Id);
        }

        public List<DTO.DespesaRateio> SelectPeloSegmento(int Id)
        {
            return new DAL.DespesaRateio().SelectPeloSegmento(Id);
        }

        public List<DTO.DespesaRateio> SelectPelaCarteira(int Id)
        {
            return new DAL.DespesaRateio().SelectPelaCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.DespesaRateio Entidade)
        {
            new DAL.DespesaRateio().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.DespesaRateio despesaRateio, List<DTO.DespesaRateioCarteira> despesaRateioCarteiras)
        {
            new DAL.DespesaRateio().Cadastro(despesaRateio);

            new BLL.DespesaRateioCarteira().Remover(despesaRateio.Id);
            foreach (DTO.DespesaRateioCarteira despesaRateioCarteira in despesaRateioCarteiras)
            {
                despesaRateioCarteira.IdDespesasRateio = despesaRateio.Id;
                despesaRateioCarteira.Id = -1;
                new BLL.DespesaRateioCarteira().Cadastro(despesaRateioCarteira);
            }
        }
    }
}
