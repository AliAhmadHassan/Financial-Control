using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation
{
    public partial class Teste2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<META HTTP-EQUIV=\"Refresh\" CONTENT=\"0; URL=Teste.aspx\">");
            string script = "abrir_popup('http://sql','Receita',800,600)";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}