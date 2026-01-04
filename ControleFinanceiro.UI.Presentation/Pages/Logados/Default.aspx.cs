using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.NomeAplicacao = "Controle Financeiro - Centro de Custos";
            Master.DescricaoAplicacao = "Orcozol Assessoria e Consultoria de Cobranças LTDA.";
        }
    }
}