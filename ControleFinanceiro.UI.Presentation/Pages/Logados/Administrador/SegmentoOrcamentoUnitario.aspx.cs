using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class SegmentoOrcamentoUnitario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaGrid();
            }
        }

        private void MontaGrid()
        {
            int IdSegmento = int.Parse(Request.QueryString.Get("IdSegmento"));
            GdvOrcamento.DataSource = new BLL.SegmentoOrcamentoUnitario().SelectPeloSegmento(IdSegmento);
            GdvOrcamento.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            PanelAlterar.Visible = true;
            txtDescricao.Text = string.Empty;
            txtValor.Text = string.Empty;
            hdfId.Value = "-1";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DTO.SegmentoOrcamentoUnitario segmentoOrcamentoUnitario = new DTO.SegmentoOrcamentoUnitario();
            segmentoOrcamentoUnitario.IdSegmento = int.Parse(Request.QueryString.Get("IdSegmento"));
            segmentoOrcamentoUnitario.Id = int.Parse(hdfId.Value);
            segmentoOrcamentoUnitario.Descricao = txtDescricao.Text;
            segmentoOrcamentoUnitario.Valor = decimal.Parse(txtValor.Text);

            new BLL.SegmentoOrcamentoUnitario().Cadastro(segmentoOrcamentoUnitario);

            MontaGrid();
        }

        protected void GdvOrcamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvOrcamento.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvOrcamento.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void Excluir(int Id)
        {
            new BLL.SegmentoOrcamentoUnitario().Remover(new BLL.SegmentoOrcamentoUnitario().SelectPelaPk(Id));

            MontaGrid();
        }

        private void PopularCampos(int Id)
        {
            DTO.SegmentoOrcamentoUnitario segmentoOrcamentoUnitario = new BLL.SegmentoOrcamentoUnitario().SelectPelaPk(Id);
            txtDescricao.Text = segmentoOrcamentoUnitario.Descricao;
            txtValor.Text = segmentoOrcamentoUnitario.Valor.ToString();
            hdfId.Value = segmentoOrcamentoUnitario.Id.ToString();
            PanelAlterar.Visible = true;
        }
    }
}