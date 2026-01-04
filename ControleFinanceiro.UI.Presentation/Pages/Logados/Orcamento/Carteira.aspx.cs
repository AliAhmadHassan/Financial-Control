using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Orcamento
{
    public partial class Carteira : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTela();
            }
        }

        private void MontaTela()
        {
            Master.NomeAplicacao = "Orçamento";
            Master.DescricaoAplicacao = "Provisionar Orçamento.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();
        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            string script = string.Format("abrir_popup('Orcamento.aspx?IdSegmento={0}','Orçamento',1024,600)", trwCarteira.SelectedValue);
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        protected void trwCarteira_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
        }
    }
}