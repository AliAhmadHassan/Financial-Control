using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Boleto
    {

        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.Boleto> Select()
        {
            return new DAL.Boleto().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.Boleto SelectPelaPK(int Id)
        {
            return new DAL.Boleto().SelectPelaPK(Id);
        }

        public List<DTO.Boleto> SelectPelaCarteira(int Id)
        {
            return new DAL.Boleto().SelectPelaCarteira(Id);
        }

        public List<DTO.Boleto> SelectPeloUsuario(int Id)
        {
            return new DAL.Boleto().SelectPeloUsuario(Id);
        }

        public List<DTO.Boleto> SelectPeloTipoPostagem(int Id)
        {
            return new DAL.Boleto().SelectPeloTipoPostagem(Id);
        }

        public virtual List<DTO.Boleto> SelectPelaReferencia(int Mes, int Ano)
        {
            return new DAL.Boleto().SelectPelaReferencia(Mes, Ano);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.Boleto Entidade)
        {
            new DAL.Boleto().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.Boleto Entidade)
        {
            new DAL.Boleto().Cadastro(Entidade);
        }
    }
}
