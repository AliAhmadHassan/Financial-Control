using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class CobNetProduto
    {
        public List<DTO.CobNetProduto> SelectPeloSegId(int Id)
        {
            return new DAL.CobNetProduto().SelectPeloSegId(Id);
        }

        public DTO.CobNetProduto SelectPelaPK(int Id)
        {
            return new DAL.CobNetProduto().SelectPelaPK(Id);
        }
    }
}
