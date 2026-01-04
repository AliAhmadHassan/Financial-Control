using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.Consolidado
{
    public partial class ConsolidadoFiltros : BasePage
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
            Master.NomeAplicacao = "Relatorio Consolidado";
            Master.DescricaoAplicacao = "Relatorio de Custo por Carteira.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();

            lstDadosBancario.DataSource = new BLL.DadosBancario().Select().OrderBy(c => c.Descricao).ToList();
            lstDadosBancario.DataTextField = "Descricao";
            lstDadosBancario.DataValueField = "Id";
            lstDadosBancario.DataBind();
        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {

            hdfCarteira.Value = trwCarteira.SelectedValue;


        }

        protected void trwCarteira_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
        }

        public static string MesReferente(int intMes)
        {
            string sMes = string.Empty;
            if (intMes == 1)
                sMes = "Janeiro";
            if (intMes == 2)
                sMes = "Fevereiro";
            if (intMes == 3)
                sMes = "Março";
            if (intMes == 4)
                sMes = "Abril";
            if (intMes == 5)
                sMes = "Maio";
            if (intMes == 6)
                sMes = "Junho";
            if (intMes == 7)
                sMes = "Julho";
            if (intMes == 8)
                sMes = "Agosto";
            if (intMes == 9)
                sMes = "Setembro";
            if (intMes == 10)
                sMes = "Outubro";
            if (intMes == 11)
                sMes = "Novembro";
            if (intMes == 12)
                sMes = "Dezembro";

            return sMes;
        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            Session["IdCarteira"] = hdfCarteira.Value;
            Session["De"] = TbDe.Text;
            Session["Ate"] = TbAte.Text;
            Session["TipoReceita"] = lstReceita.SelectedValue;
            Session["TipoDespesa"] = lstDespesa.SelectedValue;
            Session["Dedutivel"] = lstDedutivel.SelectedValue;

            List<int> contaBancaria = new List<int>();
            foreach (ListItem item in lstDadosBancario.Items)
                if (item.Selected)
                    contaBancaria.Add(Convert.ToInt32(item.Value));

            if (contaBancaria.Count == 0)
            {
                foreach (ListItem item in lstDadosBancario.Items)
                    contaBancaria.Add(Convert.ToInt32(item.Value));
            }

            Session["lstContaBancaria"] = contaBancaria;

            string script = "abrir_popup('Consolidado/Consolidado.aspx','Receita',800,600)";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

    }
}