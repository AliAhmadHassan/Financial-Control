using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Carteira
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Carteira> Select()
        {
            return new DAL.Carteira().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Carteira SelectPelaPK(int Id)
        {
            return new DAL.Carteira().SelectPelaPK(Id);
        }

        public List<DTO.Carteira> SelectPeloIdPai(int Id)
        {
            return new DAL.Carteira().SelectPeloIdPai(Id);
        }

        public virtual List<DTO.Carteira> SelectIdentado()
        {
            return new DAL.Carteira().SelectIdentado();
        }

        public virtual List<DTO.Carteira> SelectPeloPredio(int Predio)
        {
            return new DAL.Carteira().SelectPeloPredio(Predio);
        }

        public virtual List<DTO.Carteira> SelectPeloPessoas_Operacional()
        {
            return new DAL.Carteira().SelectPeloPessoas_Operacional();
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Carteira Entidade)
        {
            new DAL.Carteira().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Carteira Entidade)
        {
            new DAL.Carteira().Cadastro(Entidade);
        }
    }
}
