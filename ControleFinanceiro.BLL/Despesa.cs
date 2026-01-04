using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Despesa
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Despesa> Select()
        {
            return new DAL.Despesa().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Despesa SelectPelaPK(int Id)
        {
            return new DAL.Despesa().SelectPelaPK(Id);
        }

        public List<DTO.Despesa> SelectPeloSegmento(int Id)
        {
            return new DAL.Despesa().SelectPeloSegmento(Id);
        }

        public List<DTO.Despesa> SelectPelaCarteira(int Id)
        {
            return new DAL.Despesa().SelectPelaCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Despesa Entidade)
        {
            new DAL.Despesa().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Despesa Entidade)
        {
            new DAL.Despesa().Cadastro(Entidade);
        }
    }
}
