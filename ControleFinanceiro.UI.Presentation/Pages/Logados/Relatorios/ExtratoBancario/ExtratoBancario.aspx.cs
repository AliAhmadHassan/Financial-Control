using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.ExtratoBancario
{
    public partial class ExtratoBancario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime DataDe = (DateTime)Session["cldDe"];
                DateTime DataAte = (DateTime)Session["cldAte"];

                lblData.Text = DateTime.Now.ToString("D");
                lblReferencia.Text = string.Format("{0} e {1}", DataDe.ToString("dd/MM/yyyy"), DataAte.ToString("dd/MM/yyyy"));

                string IdDadosBancario = string.Empty;

                foreach (int aux in (List<int>)Session["lstContaBancaria"])
                {
                    IdDadosBancario += aux + ",";
                }

                List<DTO.ExtratoBancario> extratosBancarios = new BLL.ExtratoBancario().Select(DataDe, DataAte, IdDadosBancario.Substring(0, IdDadosBancario.LastIndexOf(',')), Session["Procedure"].ToString());


                GridSaldo(extratosBancarios);
                GridReceita(extratosBancarios);
                GridDespesa(extratosBancarios);

                //decimal TotalDebito = 0, TotalCredito = 0;
                //foreach (DTO.ExtratoBancario x in extratosBancarios)
                //{
                //    TotalCredito += x.Credito;
                //    TotalDebito += x.Debito;
                //}
                
                //DTO.ExtratoBancario linhaTotal = new DTO.ExtratoBancario();
                //linhaTotal.Descricao = "Total";
                //linhaTotal.Credito = TotalCredito;
                //linhaTotal.Debito = TotalDebito;

                //extratosBancarios.Add(linhaTotal);


                //gdvExtratoBancario.DataSource = extratosBancarios;
                //gdvExtratoBancario.DataBind();

                //Somatorias();
            }
        }

        private void GridSaldo(List<DTO.ExtratoBancario> extratosBancarios)
        {
            gdvSaldoInicial.Style.Add("min-width", "1024px");
            gdvSaldoInicial.DataSource = extratosBancarios.Where(c => c.Tipo.Equals(0)).ToList();
            gdvSaldoInicial.DataBind();
        }

        private void GridReceita(List<DTO.ExtratoBancario> extratosBancarios)
        {
            gdvReceitas.Style.Add("min-width", "1024px");
            gdvReceitas.DataSource = extratosBancarios.Where(c => c.Tipo.Equals(1)).ToList();
            gdvReceitas.DataBind();
        }

        private void GridDespesa(List<DTO.ExtratoBancario> extratosBancarios)
        {
            gdvDespesas.Style.Add("min-width", "1024px");
            gdvDespesas.DataSource = extratosBancarios.Where(c => c.Tipo.Equals(2)).ToList();
            gdvDespesas.DataBind();
        }

        protected void gdvExtratoBancario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            PanelDetalhes.Visible = false;
        }

        protected void gdvSaldoInicial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "Selecionado") && (gdvSaldoInicial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text != "Total"))
            {
                string descricao = gdvSaldoInicial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                if (descricao.Contains("amentos)"))
                    descricao = ControleFinanceiro.UI.Presentation.App_Code.Cs_Html.AcertaHtmlAcentro(descricao.Remove(descricao.LastIndexOf('(') - 1));

                DateTime DataDe = Convert.ToDateTime(gdvSaldoInicial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                DateTime DataAte = Convert.ToDateTime(gdvSaldoInicial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

                string IdDadosBancario = string.Empty;
                foreach (int aux in (List<int>)Session["lstContaBancaria"])
                {
                    IdDadosBancario += aux + ",";
                }

                List<DTO.ExtratoBancario> extratosBancarios = new BLL.ExtratoBancario().Select(DataDe, DataAte, IdDadosBancario.Substring(0, IdDadosBancario.LastIndexOf(',')), Session["Procedure"].ToString(), descricao);

                gdvDetalhes.DataSource = extratosBancarios;
                gdvDetalhes.DataBind();

                PanelDetalhes.Visible = true;
            }
        }

        protected void gdvReceitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "Selecionado") && (gdvReceitas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text != "Total"))
            {
                string descricao = gdvReceitas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                if (descricao.Contains("amentos)"))
                    descricao = ControleFinanceiro.UI.Presentation.App_Code.Cs_Html.AcertaHtmlAcentro(descricao.Remove(descricao.LastIndexOf('(') - 1));

                DateTime DataDe = Convert.ToDateTime(gdvReceitas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                DateTime DataAte = Convert.ToDateTime(gdvReceitas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

                string IdDadosBancario = string.Empty;
                foreach (int aux in (List<int>)Session["lstContaBancaria"])
                {
                    IdDadosBancario += aux + ",";
                }

                List<DTO.ExtratoBancario> extratosBancarios = new BLL.ExtratoBancario().Select(DataDe, DataAte, IdDadosBancario.Substring(0, IdDadosBancario.LastIndexOf(',')), Session["Procedure"].ToString(), descricao);

                gdvDetalhes.DataSource = extratosBancarios;
                gdvDetalhes.DataBind();

                PanelDetalhes.Visible = true;
            }
        }

        protected void gdvDespesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName == "Selecionado") && (gdvDespesas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text != "Total"))
            {
                string descricao = gdvDespesas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                if (descricao.Contains("amentos)"))
                    descricao = ControleFinanceiro.UI.Presentation.App_Code.Cs_Html.AcertaHtmlAcentro(descricao.Remove(descricao.LastIndexOf('(') - 1));

                DateTime DataDe = Convert.ToDateTime(gdvDespesas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                DateTime DataAte = Convert.ToDateTime(gdvDespesas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

                string IdDadosBancario = string.Empty;
                foreach (int aux in (List<int>)Session["lstContaBancaria"])
                {
                    IdDadosBancario += aux + ",";
                }

                List<DTO.ExtratoBancario> extratosBancarios = new BLL.ExtratoBancario().Select(DataDe, DataAte, IdDadosBancario.Substring(0, IdDadosBancario.LastIndexOf(',')), Session["Procedure"].ToString(), descricao);

                gdvDetalhes.DataSource = extratosBancarios;
                gdvDetalhes.DataBind();

                PanelDetalhes.Visible = true;
            }
        }

        decimal sumSaldoInicial = 0;
        protected void gdvSaldoInicial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                sumSaldoInicial += Convert.ToDecimal(e.Row.Cells[2].Text.Replace("R$", "").Replace(" ", ""));

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = sumSaldoInicial.ToString("c2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                lblSaldoInicial.Text = sumSaldoInicial.ToString("c2");
            }

        }

        decimal sumReceitas = 0;
        protected void gdvReceitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                sumReceitas += Convert.ToDecimal(e.Row.Cells[2].Text.Replace("R$", "").Replace(" ", ""));

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = sumReceitas.ToString("c2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                lblReceitas.Text = sumReceitas.ToString("c2");
            }
        }

        decimal sumDespesas = 0;
        protected void gdvDespesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                sumDespesas += Convert.ToDecimal(e.Row.Cells[2].Text.Replace("R$", "").Replace(" ", ""));

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = sumDespesas.ToString("c2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                lblDespesas.Text = sumDespesas.ToString("c2");
                lblTotalGeral.Text = (sumSaldoInicial + sumReceitas + sumDespesas).ToString("c2");
            }
        }

    }
}