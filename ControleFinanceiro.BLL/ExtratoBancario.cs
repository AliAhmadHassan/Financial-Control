using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class ExtratoBancario
    {
        public virtual List<DTO.ExtratoBancario> Select(DateTime DataDe, DateTime DataAte, string IdDadosBancario, string Procedure)
        {
            return Select(DataDe, DataAte, IdDadosBancario, Procedure, "");
        }
        public virtual List<DTO.ExtratoBancario> Select(DateTime DataDe, DateTime DataAte, string IdDadosBancario, string Procedure, string Descricao)
        {
            return new DAL.ExtratoBancario().Select(DataDe, DataAte, IdDadosBancario, Procedure, Descricao);
        }
    }
}
