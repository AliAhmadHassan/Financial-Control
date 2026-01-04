using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class BoletoCarteira
    {

        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.BoletoCarteira> Select()
        {
            return new DAL.BoletoCarteira().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.BoletoCarteira SelectPelaPK(int Id)
        {
            return new DAL.BoletoCarteira().SelectPelaPK(Id);
        }


        public List<DTO.BoletoCarteira> SelectPelaIdCarteira(int Id)
        {
            return new DAL.BoletoCarteira().SelectPelaIdCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.BoletoCarteira Entidade)
        {
            new DAL.BoletoCarteira().Remover(Entidade);
        }

        public void RemovePelaIdCarteira(int Id)
        {
            new DAL.BoletoCarteira().RemovePelaIdCarteira(Id);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.BoletoCarteira Entidade)
        {
            new DAL.BoletoCarteira().Cadastro(Entidade);
        }
    }
}
