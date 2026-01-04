using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class CobNetSegmento
    {
        public List<DTO.CobNetSegmento> SelectPeloCredId(int Id)
        {
            return new DAL.CobNetSegmento().SelectPeloCredId(Id);
        }

        public DTO.CobNetSegmento SelectPelaPK(int Id)
        {
            return new DAL.CobNetSegmento().SelectPelaPK(Id);
        }
    }
}
