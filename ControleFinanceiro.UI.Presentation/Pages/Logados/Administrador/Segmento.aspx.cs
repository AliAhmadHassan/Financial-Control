using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class Segmento : BasePage
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
            Master.NomeAplicacao = "Cadastro Segmento";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção de Segmentos.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
            tree.DataSource = new BLL.Segmento().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwSegmento.Nodes.Clear();
            trwSegmento.Nodes.Add(tree.DataBind());
            trwSegmento.DataBind();

            lstTipoSegmento.DataSource = new BLL.TipoSegmento().Select();
            lstSubTipoSegmento.DataSource = new BLL.TipoSegmento().Select();
            lstTipoSegmento.DataTextField = "Tipo";
            lstSubTipoSegmento.DataTextField = "Tipo";
            lstTipoSegmento.DataValueField = "Id";
            lstSubTipoSegmento.DataValueField = "Id";
            lstTipoSegmento.DataBind();
            lstSubTipoSegmento.DataBind();


            RBLTipoDespesa.DataSource = new BLL.SegmentoTipoDespesa().Select();
            RBLTipoDespesa.DataTextField = "Descricao";
            RBLTipoDespesa.DataValueField = "Id";
            RBLTipoDespesa.DataBind();

            RBLSubTipoDespesa.DataSource = new BLL.SegmentoTipoDespesa().Select();
            RBLSubTipoDespesa.DataTextField = "Descricao";
            RBLSubTipoDespesa.DataValueField = "Id";
            RBLSubTipoDespesa.DataBind();
        }

        protected void btNovo_Click(object sender, EventArgs e)
        {

        }

        protected void trwSegmento_SelectedNodeChanged(object sender, EventArgs e)
        {
            DTO.Segmento segmento = new BLL.Segmento().SelectPelaPK(trwSegmento.SelectedValue.ToInt());

            txtDescricao.Text = segmento.Descricao;
            lstTipoSegmento.SelectedValue = segmento.IdTipoSegmento.ToString();
            PanelAlterar.Visible = true;
            hdfIdsegmento.Value = trwSegmento.SelectedValue;
            RBLTipoDespesa.SelectedValue = segmento.IdTipoDespesas.ToString();
        }

        protected void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Segmento segmento = new BLL.Segmento().SelectPelaPK(hdfIdsegmento.Value.ToInt());
                segmento.Descricao = txtDescricao.Text;
                segmento.IdTipoSegmento = lstTipoSegmento.SelectedValue.ToInt();
                segmento.IdTipoDespesas = RBLTipoDespesa.SelectedValue.ToInt();
                new BLL.Segmento().Cadastro(segmento);
                MontaTela();
                Master.ShowMessage("Alterado com Sucesso!");
            }
            catch (Exception Erro)
            {
                Master.ShowMessage(Erro.Message);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubDescricao.Text))
            {
                Master.ShowMessage("Favor Preencher uma descrição!");
                return;
            }
            else if (lstSubTipoSegmento.SelectedValue == string.Empty)
            {
                Master.ShowMessage("Favor Selecionar um Tipo de Segmento!");
                return;
            }


            try
            {
                DTO.Segmento segmento = new DTO.Segmento();
                segmento.Descricao = txtSubDescricao.Text;
                segmento.IdTipoSegmento = lstSubTipoSegmento.SelectedValue.ToInt();
                segmento.IdPai = hdfIdsegmento.Value.ToInt();
                segmento.IdTipoDespesas = RBLSubTipoDespesa.SelectedValue.ToInt();
                new BLL.Segmento().Cadastro(segmento);
                MontaTela();
                Master.ShowMessage("Cadastrado com Sucesso!");

                txtSubDescricao.Text = string.Empty;
                PanelAlterar.Visible = false;

            }
            catch (Exception Erro)
            {
                Master.ShowMessage(Erro.Message);
            }
        }

        protected void btnOrcamento_Click(object sender, EventArgs e)
        {
            string script = string.Format("abrir_popup('SegmentoOrcamentoUnitario.aspx?IdSegmento={0}','Orçamento',800,600)", hdfIdsegmento.Value);
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}