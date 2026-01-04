using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class STIRamal
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.STIRamal> Select()
        {
            return new DAL.STIRamal().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.STIRamal SelectPelaPK(int Id)
        {
            return new DAL.STIRamal().SelectPelaPK(Id);
        }

        public List<DTO.STIRamal> SelectPeloRamal(int Id)
        {
            return new DAL.STIRamal().SelectPeloRamal(Id);
        }

        public virtual List<DTO.STIRamal> SelectPelaCarteira(int Id)
        {
            return new DAL.STIRamal().SelectPelaCarteira(Id);
        }
        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.STIRamal Entidade)
        {
            new DAL.STIRamal().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.STIRamal Entidade)
        {
            new DAL.STIRamal().Cadastro(Entidade);
        }
    }
}
