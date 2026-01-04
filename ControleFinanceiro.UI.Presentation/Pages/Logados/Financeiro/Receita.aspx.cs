using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;
using System.IO;
using System.Net;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class Receita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfIdSegmento.Value = Request.QueryString.Get("IdSegmento");
                hdfIdCarteira.Value = Request.QueryString.Get("IdCarteira");
                hdfMesReferencia.Value = Request.QueryString.Get("MesReferencia");

                MontaGrid();

                lstDadosBancario.DataSource = new BLL.DadosBancario().Select();
                lstDadosBancario.DataTextField = "Descricao";
                lstDadosBancario.DataValueField = "Id";
                lstDadosBancario.DataBind();
            }
        }
        protected void MontaGrid()
        {
            if ((hdfIdSegmento.Value != string.Empty) && (hdfIdCarteira.Value != string.Empty))
            {
                List<DTO.Receita> receita = new BLL.Receita().SelectPeloSegmento(hdfIdSegmento.Value.ToInt());
                int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[1].ToInt();

                GdvReceita.DataSource = receita.Where(c => c.IdCarteira.Equals(hdfIdCarteira.Value.ToInt()) && c.Referencia.Month.Equals(Mes) && c.Referencia.Year.Equals(Ano)).ToList();
                GdvReceita.DataBind();
            }
        }

        protected void BtnCadastroSim_Click(object sender, EventArgs e)
        {

            int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[0].ToInt();

            DTO.Receita receita = hdfIdReceita.Value == "-1" ? new DTO.Receita() : new BLL.Receita().SelectPelaPK(hdfIdReceita.Value.ToInt());

            if (FUpCartaCorrecao.HasFile)
            {
                receita.CartaCorrecao = FUpCartaCorrecao.FileBytes;
                receita.ExtensaoCartaCorrecao = FUpCartaCorrecao.FileName.Substring(FUpCartaCorrecao.FileName.LastIndexOf('.'));
            }
            if (FUpNota.HasFile)
            {
                receita.ExtensaoNOTA = FUpNota.FileName.Substring(FUpNota.FileName.LastIndexOf('.'));
                receita.NOTA = FUpNota.FileBytes;
            }
            receita.Cofins = txtCofins.Text.ToDecimal();
            receita.CSLL = txtCSLL.Text.ToDecimal();
            receita.Dedutivel = cbDedutivel.Checked;
            receita.Emissao = txtEmissao.Text.ToDateTime();
            receita.IdCarteira = hdfIdCarteira.Value.ToInt();
            receita.IdDadosBancario = lstDadosBancario.SelectedValue.ToInt();
            receita.IdSegmento = hdfIdSegmento.Value.ToInt();
            receita.IdUsuario = ((DTO.Usuario)Session["Usuario"]).Id;
            receita.IRPJ = txtIRPJ.Text.ToDecimal();
            receita.ISS = txtISS.Text.ToDecimal();
            receita.NotaFiscal = CbNotaFiscal.Checked;
            receita.NumeroNota = txtNumeroNota.Text.ToInt();
            receita.Obs = txtObs.Text;
            receita.PIS = txtPIS.Text.ToDecimal();
            receita.Referencia = Convert.ToDateTime("01/" + hdfMesReferencia.Value);
            receita.Valor = txtValor.Text.ToDecimal();
            receita.Vencimento = txtVencimento.Text.ToDateTime();
            if (!string.IsNullOrEmpty(txtDtPgto.Text))
                receita.DtPgto = txtDtPgto.Text.ToDateTime();
            try
            {
                new BLL.Receita().Cadastro(receita);
                MontaGrid();
                MensagemOK.ShowMessage("Receita Cadastrado com Sucesso!");

            }
            catch (Exception erro)
            {
                MensagemOK.ShowMessage(erro.Message);
            }

            hdfIdReceita.Value = "-1";
        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {
            hdfIdReceita.Value = "-1";
        }

        protected void GdvReceita_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvReceita.PageIndex = e.NewPageIndex;
            MontaGrid();
        }

        protected void GdvReceita_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[7].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[7].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "ExibirNota":
                    {
                        DTO.Receita receita = new BLL.Receita().SelectPelaPK(int.Parse(GdvReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[7].Text.Replace("&nbsp;", string.Empty)));
                        if (receita.NOTA == null)
                        {
                            MensagemOK.ShowMessage("Nota Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(receita.NOTA, receita.ExtensaoNOTA);
                    }
                    break;

                case "ExibirCartaCorrecao":
                    {
                        DTO.Receita receita = new BLL.Receita().SelectPelaPK(int.Parse(GdvReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[7].Text.Replace("&nbsp;", string.Empty)));
                        if (receita.CartaCorrecao == null)
                        {
                            MensagemOK.ShowMessage("Carta Correcao Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(receita.CartaCorrecao, receita.ExtensaoCartaCorrecao);
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
            DTO.Receita receita = new BLL.Receita().SelectPelaPK(id);
            new BLL.Receita().Remover(receita);
            MontaGrid();
        }

        private void PopularCampos(int id)
        {
            DTO.Receita receita = new BLL.Receita().SelectPelaPK(id);
            hdfIdReceita.Value = receita.Id.ToString();
            txtCofins.Text = receita.Cofins.ToString();
            txtCSLL.Text = receita.CSLL.ToString();
            cbDedutivel.Checked = receita.Dedutivel;
            txtEmissao.Text = receita.Emissao.ToString();
            lstDadosBancario.SelectedValue = receita.IdDadosBancario.ToString();
            txtIRPJ.Text = receita.IRPJ.ToString();
            txtISS.Text = receita.ISS.ToString();
            CbNotaFiscal.Checked = receita.NotaFiscal;
            txtNumeroNota.Text = receita.NumeroNota.ToString();
            txtObs.Text = receita.Obs;
            txtPIS.Text = receita.PIS.ToString();
            txtValor.Text = receita.Valor.ToString();
            txtVencimento.Text = receita.Vencimento.ToString();
            txtDtPgto.Text = receita.DtPgto.ToString();

            Panel_Cadastro_ModalPopupExtender.Show();
        }

        protected void GdvReceita_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[6].Text = new BLL.Usuario().SelectPelaPK(e.Row.Cells[6].Text.ToInt()).Nome;

            //if (e.Row.Cells[2].Text == "01/01/0001")
            //    e.Row.Cells[2].Text = string.Empty;
            //if (e.Row.Cells[3].Text == "01/01/0001")
            //    e.Row.Cells[3].Text = string.Empty;
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            hdfIdReceita.Value = "-1";
            Panel_Cadastro_ModalPopupExtender.Show();
        }
    }
}