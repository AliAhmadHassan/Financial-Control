using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Receita
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Receita> Select()
        {
            return new DAL.Receita().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Receita SelectPelaPK(int Id)
        {
            return new DAL.Receita().SelectPelaPK(Id);
        }

        public List<DTO.Receita> SelectPeloSegmento(int Id)
        {
            return new DAL.Receita().SelectPeloSegmento(Id);
        }

        public List<DTO.Receita> SelectPelaCarteira(int Id)
        {
            return new DAL.Receita().SelectPelaCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Receita Entidade)
        {
            new DAL.Receita().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Receita Entidade)
        {
            new DAL.Receita().Cadastro(Entidade);
        }
    }
}
