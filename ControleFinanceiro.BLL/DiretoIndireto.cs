using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class DiretoIndireto
    {
        public List<DTO.DiretoIndireto> Select(DateTime De, DateTime Ate, int IdCarteira)
        {
            return new DAL.DiretoIndireto().Select(De, Ate, IdCarteira);
        }
    }
}
