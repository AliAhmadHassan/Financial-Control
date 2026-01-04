using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Segmento
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Segmento> Select()
        {
            return new DAL.Segmento().Select(); 

        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Segmento SelectPelaPK(int Id)
        {
            return new DAL.Segmento().SelectPelaPK(Id);
        }

        public List<DTO.Segmento> SelectPeloIdPai(int Id)
        {
            return new DAL.Segmento().SelectPeloIdPai(Id);
        }

        public List<DTO.Segmento> SelectPeloTipo(int Id)
        {
            return new DAL.Segmento().SelectPeloTipo(Id);
        }

        public List<DTO.Segmento> SelectIdentado()
        {
            return new DAL.Segmento().SelectIdentado();
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Segmento Entidade)
        {
            new DAL.Segmento().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Segmento Entidade)
        {
            new DAL.Segmento().Cadastro(Entidade);
        }
    }
}
