using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class HistoricoFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            { 
                Label lb = (Label)e.Row.FindControl("LbCarteira");
                if (lb != null)
                    lb.Text = new BLL.Carteira().SelectPelaPK(Convert.ToInt32(lb.Text)).Descricao;
            }
        }
    }
}