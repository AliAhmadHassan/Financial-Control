using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class SegmentoTipoDespesa
    {
        public List<DTO.SegmentoTipoDespesa> Select()
        {
            return new DAL.SegmentoTipoDespesa().Select();
        }
    }
}
