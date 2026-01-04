using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class CobNetCredor
    {
        public List<DTO.CobNetCredor> Select()
        {
            return new DAL.CobNetCredor().Select();
        }
    }
}
