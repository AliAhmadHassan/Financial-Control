using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios
{
    public partial class SegmentoCarteiraFiltros : BasePage
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
            Master.NomeAplicacao = "Relatorio Segmento/Grupo";
            Master.DescricaoAplicacao = "Extrair todas as informações cadastradas pelo Segmento ou Grupo.";

            {
                ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
                tree.DataSource = new BLL.Carteira().Select();
                tree.Id = "Id";
                tree.Descricao = "Descricao";
                tree.IdPai = "IdPai";

                trwCarteira.Nodes.Clear();
                trwCarteira.Nodes.Add(tree.DataBind());
                trwCarteira.DataBind();
            }

            {
                ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
                tree.DataSource = new BLL.Segmento().Select();
                tree.Id = "Id";
                tree.Descricao = "Descricao";
                tree.IdPai = "IdPai";

                trwSegmento.Nodes.Clear();
                trwSegmento.Nodes.Add(tree.DataBind());
                trwSegmento.DataBind();
            }
        }

        protected void trwSegmento_SelectedNodeChanged(object sender, EventArgs e)
        {
            DateTime aux;
            if (!DateTime.TryParse(TbDe.Text, out aux))
            {
                Master.ShowMessage("Data Definido Incorretamente");
                return;
            }

            if (!DateTime.TryParse(TbAte.Text, out aux))
            {
                Master.ShowMessage("Data Definido Incorretamente");
                return;
            }

            Session.Remove("IdCarteira");
            Session["IdSegmento"] = trwSegmento.SelectedValue;
            Session["De"] = TbDe.Text;
            Session["Ate"] = TbAte.Text;
            Session["TipoReceita"] = lstReceita.SelectedValue;
            Session["TipoDespesa"] = lstDespesa.SelectedValue;

            string script = "abrir_popup('SegmentoCarteira/SegmentoCarteira.aspx','Receita_Despesas',800,600);";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            DateTime aux;
            if (!DateTime.TryParse(TbDe.Text, out aux))
            {
                Master.ShowMessage("Data Definido Incorretamente");
                return;
            }

            if (!DateTime.TryParse(TbAte.Text, out aux))
            {
                Master.ShowMessage("Data Definido Incorretamente");
                return;
            }

            Session.Remove("IdSegmento");
            Session["IdCarteira"] = trwCarteira.SelectedValue;
            Session["De"] = TbDe.Text;
            Session["Ate"] = TbAte.Text;
            Session["TipoReceita"] = lstReceita.SelectedValue;
            Session["TipoDespesa"] = lstDespesa.SelectedValue;

            string script = "abrir_popup('SegmentoCarteira/SegmentoCarteira.aspx','Receita_Despesas',800,600);";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}