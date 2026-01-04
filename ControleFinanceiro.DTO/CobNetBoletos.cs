using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class CobNetBoletos:Base
    {
        public int Cred_Id { get; set; }
        public int Seg_Id { get; set; }
        public int Prod_Id { get; set; }
        public int Qtd { get; set; }
    }
}
