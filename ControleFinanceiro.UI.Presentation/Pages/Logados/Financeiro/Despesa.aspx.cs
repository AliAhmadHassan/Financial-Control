using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class Despesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfIdSegmento.Value = Request.QueryString.Get("IdSegmento");
                hdfIdCarteira.Value = Request.QueryString.Get("IdCarteira");
                hdfMesReferencia.Value = Request.QueryString.Get("MesReferencia");

                MontaGrid();

                lstDadosBancario.DataSource = new BLL.DadosBancario().Select().OrderBy(c => c.Descricao).ToList();
                lstDadosBancario.DataTextField = "Descricao";
                lstDadosBancario.DataValueField = "Id";
                lstDadosBancario.DataBind();

                lstFornecedor.DataSource = new BLL.Fornecedor().Select().OrderBy(c=>c.Nome).ToList();
                lstFornecedor.DataTextField = "Nome";
                lstFornecedor.DataValueField = "Id";
                lstFornecedor.DataBind();
            }
        }
        protected void MontaGrid()
        {
            if ((hdfIdSegmento.Value != string.Empty) && (hdfIdCarteira.Value != string.Empty))
            {
                List<DTO.Despesa> Despesa = new BLL.Despesa().SelectPeloSegmento(hdfIdSegmento.Value.ToInt());
                int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[1].ToInt();

                GdvDespesa.DataSource = Despesa.Where(c => c.IdCarteira.Equals(hdfIdCarteira.Value.ToInt()) && c.Vencimento.Month.Equals(Mes) && c.Vencimento.Year.Equals(Ano)).ToList();
                GdvDespesa.DataBind();
            }
        }

        protected void BtnCadastroSim_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ddlMeses.SelectedValue.ToInt(); i++)
            {

                int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[0].ToInt();

                DTO.Despesa Despesa = hdfIdDespesa.Value == "-1" ? new DTO.Despesa() : new BLL.Despesa().SelectPelaPK(hdfIdDespesa.Value.ToInt());
                if (FUpBoleto.HasFile)
                {
                    Despesa.ExtensaoBoleto = FUpBoleto.FileName.Substring(FUpBoleto.FileName.LastIndexOf('.'));
                    Despesa.Boleto = FUpBoleto.FileBytes;
                }
                if (FUpNota.HasFile)
                {
                    Despesa.ExtensaoNota = FUpNota.FileName.Substring(FUpNota.FileName.LastIndexOf('.'));
                    Despesa.Nota = FUpNota.FileBytes;
                }
                if (FUpComprovante.HasFile)
                {
                    Despesa.ExtensaoComprovante = FUpComprovante.FileName.Substring(FUpComprovante.FileName.LastIndexOf('.'));
                    Despesa.Comprovante = FUpComprovante.FileBytes;
                }
                Despesa.Cofins = txtCofins.Text.ToDecimal();
                Despesa.CSLL = txtCSLL.Text.ToDecimal();
                Despesa.Dedutivel = cbDedutivel.Checked;
                Despesa.Emissao = txtEmissao.Text.ToDateTime().AddMonths(i);
                Despesa.IdCarteira = hdfIdCarteira.Value.ToInt();
                Despesa.IdDadosBancario = lstDadosBancario.SelectedValue.ToInt();
                Despesa.IdSegmento = hdfIdSegmento.Value.ToInt();
                Despesa.IdUsuario = ((DTO.Usuario)Session["Usuario"]).Id;
                Despesa.IRPJ = txtIRPJ.Text.ToDecimal();
                Despesa.ISS = txtISS.Text.ToDecimal();
                Despesa.NumeroDocumento = txtNumeroDocumento.Text.ToInt();

                if (i == 0)
                {
                    if (!string.IsNullOrEmpty(txtDtPgto.Text))
                        Despesa.DtPgto = txtDtPgto.Text.ToDateTime();
                }

                Despesa.Descricao = txtDescricao.Text;
                Despesa.PIS = txtPIS.Text.ToDecimal();
                Despesa.Valor = txtValor.Text.ToDecimal();

                Despesa.Vencimento = txtVencimento.Text.ToDateTime().AddMonths(i);

                Despesa.IdFornecedor = lstFornecedor.SelectedValue.ToInt();
                try
                {
                    new BLL.Despesa().Cadastro(Despesa);
                    MontaGrid();
                    MensagemOK.ShowMessage("Despesa Cadastrado com Sucesso!");
                }
                catch (Exception erro)
                {
                    MensagemOK.ShowMessage(erro.Message);
                }
            }
        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void GdvDespesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvDespesa.PageIndex = e.NewPageIndex;
            MontaGrid();
        }

        protected void GdvDespesa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "ExibirNota":
                    {
                        DTO.Despesa Despesa = new BLL.Despesa().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (Despesa.Nota == null)
                        {
                            MensagemOK.ShowMessage("Nota Não Inclusa na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(Despesa.Nota, Despesa.ExtensaoNota);
                    }
                    break;

                case "ExibirBoleto":
                    {
                        DTO.Despesa despesa = new BLL.Despesa().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (despesa.Boleto == null)
                        {
                            MensagemOK.ShowMessage("Boleto Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(despesa.Boleto, despesa.ExtensaoBoleto);
                    }
                    break;

                case "ExibirComprovante":
                    {
                        DTO.Despesa despesa = new BLL.Despesa().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (despesa.Comprovante == null)
                        {
                            MensagemOK.ShowMessage("Comprovante Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(despesa.Comprovante, despesa.ExtensaoComprovante);
                    }
                    break;
            }
        }

        private void ExibirArquivo(Byte[] Arquivo, string Extensao)
        {

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"Document" + Extensao + "\"");
            response.BinaryWrite(Arquivo);
            response.End();
        }

        private void Excluir(int id)
        {
            DTO.Despesa Despesa = new BLL.Despesa().SelectPelaPK(id);
            new BLL.Despesa().Remover(Despesa);
            MontaGrid();
        }

        private void PopularCampos(int id)
        {
            DTO.Despesa Despesa = new BLL.Despesa().SelectPelaPK(id);
            hdfIdDespesa.Value = Despesa.Id.ToString();
            txtCofins.Text = Despesa.Cofins.ToString();
            txtCSLL.Text = Despesa.CSLL.ToString();
            cbDedutivel.Checked = Despesa.Dedutivel;
            txtEmissao.Text = Despesa.Emissao.ToString();
            lstDadosBancario.SelectedValue = Despesa.IdDadosBancario.ToString();

            if (Despesa.IdFornecedor != 0)
                lstFornecedor.SelectedValue = Despesa.IdFornecedor.ToString();

            txtIRPJ.Text = Despesa.IRPJ.ToString();
            txtISS.Text = Despesa.ISS.ToString();
            txtNumeroDocumento.Text = Despesa.NumeroDocumento.ToString();
            txtDtPgto.Text = Despesa.DtPgto.ToString();
            txtDescricao.Text = Despesa.Descricao;
            txtPIS.Text = Despesa.PIS.ToString();
            txtValor.Text = Despesa.Valor.ToString();
            txtVencimento.Text = Despesa.Vencimento.ToString();

            Panel_Cadastro_ModalPopupExtender.Show();
        }

        protected void GdvDespesa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[8].Text = new BLL.Usuario().SelectPelaPK(e.Row.Cells[8].Text.ToInt()).Nome;
                if (e.Row.Cells[2].Text == "01/01/0001")
                    e.Row.Cells[2].Text = string.Empty;
                if (e.Row.Cells[3].Text == "01/01/0001")
                    e.Row.Cells[3].Text = string.Empty;
                if (e.Row.Cells[4].Text == "01/01/0001")
                    e.Row.Cells[4].Text = string.Empty;
                if (e.Row.Cells[5].Text == "01/01/0001")
                    e.Row.Cells[5].Text = string.Empty;                
            }
        }
    }
}