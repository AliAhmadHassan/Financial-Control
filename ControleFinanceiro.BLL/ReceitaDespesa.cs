using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class ReceitaDespesa
    {
        /// <summary>
        /// Retorna Toda a tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <returns>Lista do tipo de Entidade informada</returns>
        public List<DTO.ReceitaDespesa> Select()
        {
            return new DAL.ReceitaDespesa().Select();
        }

        /// <summary>
        /// Perquisa o Registro pela Chave Primaria da Tabela
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Id">Valor da Chave Primaria</param>
        /// <returns>Retorna a Entidade Informada</returns>
        public DTO.ReceitaDespesa SelectPelaPK(int Id)
        {
            return new DAL.ReceitaDespesa().SelectPelaPK(Id);
        }

        public List<DTO.ReceitaDespesa> SelectPelaCarteira(int Id)
        {
            return new DAL.ReceitaDespesa().SelectPelaCarteira(Id);
        }

        public List<DTO.ReceitaDespesa> SelectPelaUsuario(int Id)
        {
            return new DAL.ReceitaDespesa().SelectPelaUsuario(Id);
        }

        public List<DTO.ReceitaDespesa> SelectPeloSegmento(int Id)
        {
            return new DAL.ReceitaDespesa().SelectPeloSegmento(Id);
        }

        public virtual List<DTO.ReceitaDespesa> SelectPelaReferencia(int Mes, int Ano)
        {
            return new DAL.ReceitaDespesa().SelectPelaReferencia(Mes, Ano);
        }

        /// <summary>
        /// Entidade a ser Removida do Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser Removido</param>
        public void Remover(DTO.ReceitaDespesa Entidade)
        {
            new DAL.ReceitaDespesa().Remover(Entidade);
        }

        /// <summary>
        /// Metodo para inserir/alterar registro no Banco de Dados
        /// </summary>
        /// <typeparam name="T">Tipo da Entidade</typeparam>
        /// <param name="Entidade">Nome da Entidade a ser inserido</param>
        public void Cadastro(DTO.ReceitaDespesa Entidade)
        {
            new DAL.ReceitaDespesa().Cadastro(Entidade);
        }
    }
}
