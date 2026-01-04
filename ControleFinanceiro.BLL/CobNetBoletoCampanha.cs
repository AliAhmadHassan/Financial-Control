using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class CobNetBoletoCampanha
    {
        public virtual List<DTO.CobNetBoletoCarteira> Select(string Credores, string Segmentos, string Produtos)
        {
            return new DAL.CobNetBoletoCarteira().Select(Credores, Segmentos, Produtos);
        }

    }
}
