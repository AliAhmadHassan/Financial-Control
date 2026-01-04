using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class ControleAcesso
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.ControleAcesso> Select()
        {
            return new DAL.ControleAcesso().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.ControleAcesso SelectPelaPK(int Id)
        {
            return new DAL.ControleAcesso().SelectPelaPK(Id);
        }

        public List<DTO.ControleAcesso> SelectPelaCarteira(int Id)
        {
            return new DAL.ControleAcesso().SelectPelaCarteira(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.ControleAcesso Entidade)
        {
            new DAL.ControleAcesso().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.ControleAcesso Entidade)
        {
            new DAL.ControleAcesso().Cadastro(Entidade);
        }


    }
}
