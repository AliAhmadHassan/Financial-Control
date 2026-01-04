using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Discador
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Discador> Select()
        {
            return new DAL.Discador().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Discador SelectPelaPK(int Id)
        {
            return new DAL.Discador().SelectPelaPK(Id);
        }

        public List<DTO.Discador> SelectPelaCarteira(int Id)
        {
            return new DAL.Discador().SelectPelaCarteira(Id);
        }

        public List<DTO.Discador> SelectPeloUsuario(int Id)
        {
            return new DAL.Discador().SelectPeloUsuario(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Discador Entidade)
        {
            new DAL.Discador().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Discador Entidade)
        {
            new DAL.Discador().Cadastro(Entidade);
        }
    }
}
