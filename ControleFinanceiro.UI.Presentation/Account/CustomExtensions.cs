using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.App_Code
{
    public static class StringExtension
    {
        public static int ToInt(this String str)
        {
            int aux = 0;

            if (!string.IsNullOrEmpty(str))
                if (!int.TryParse(str, out aux))
                    throw new Exception("Erro ao converter para Inteiro");

            return aux;
        }

        public static decimal ToDecimal(this String str)
        {
            decimal aux = 0;

            if (!string.IsNullOrEmpty(str))
                if (!decimal.TryParse(str, out aux))
                    throw new Exception("Erro ao converter para Decimal");

            return aux;
        }

        public static DateTime ToDateTime(this String str)
        {
            DateTime aux;

            if (!DateTime.TryParse(str, out aux))
                throw new Exception("Erro ao converter para DateTime");

            return aux;
        }
    }
}