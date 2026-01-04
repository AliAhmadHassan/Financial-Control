using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DAL
{
    public static class Conexao
    {
        public static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringControleFinanceiro"].ConnectionString.ToString();
        public static string strConnCobNet = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringCobNet"].ConnectionString.ToString();
        public static string strConnControleAcesso = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringControleAcesso"].ConnectionString.ToString();
    }
}
