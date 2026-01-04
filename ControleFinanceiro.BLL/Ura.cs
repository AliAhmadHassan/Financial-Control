using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Ura
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Ura> Select()
        {
            return new DAL.Ura().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Ura SelectPelaPK(int Id)
        {
            return new DAL.Ura().SelectPelaPK(Id);
        }

        public List<DTO.Ura> SelectPelaCarteira(int Id)
        {
            return new DAL.Ura().SelectPelaCarteira(Id);
        }

        public List<DTO.Ura> SelectPeloUsuario(int Id)
        {
            return new DAL.Ura().SelectPeloUsuario(Id);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Ura Entidade)
        {
            new DAL.Ura().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Ura Entidade)
        {
            new DAL.Ura().Cadastro(Entidade);
        }
    }
}
