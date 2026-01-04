using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Consolidado
    {
        public List<DTO.Consolidado> Select(DateTime De, DateTime Ate, int IdCarteira, int Dedutivel, int Receita, int Despesas, string IdDadosBancario)
        {
            return new DAL.Consolidado().Select(De, Ate, IdCarteira, Dedutivel, Receita, Despesas, IdDadosBancario);
        }
    }
}
