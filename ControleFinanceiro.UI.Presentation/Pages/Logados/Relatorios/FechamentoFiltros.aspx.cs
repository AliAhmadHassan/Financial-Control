using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios
{
    public partial class FechamentoFiltros : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlReferencia.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = MesReferente(DateTime.Today.AddMonths(-i).Month) + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");
                    item.Value = DateTime.Today.AddMonths(-i).Month.ToString("00") + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");

                    if (i == 0)
                        item.Selected = true;
                    else
                        item.Selected = false;

                    ddlReferencia.Items.Add(item);
                }
            }
        }
        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            string script = string.Format("abrir_popup('Fechamento/Fechamento.aspx?MesReferencia={0}','Fechamento',800,600);", ddlReferencia.SelectedValue);
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);

        }
    }
}