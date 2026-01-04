using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;
using System.Text;
using System.IO;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.ExtratoBancario
{
    public partial class ExtratoBancarioFiltros : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cldDe.SelectedDate = DateTime.Today;
                cldAte.SelectedDate = DateTime.Today;

                lstContaBancaria.Items.Clear();
                lstContaBancaria.DataSource = new BLL.DadosBancario().Select();
                lstContaBancaria.DataTextField = "Descricao";
                lstContaBancaria.DataValueField = "Id";
                lstContaBancaria.DataBind();

                Master.NomeAplicacao = "Extrato Bancario";
                Master.DescricaoAplicacao = "Relatorio das Contas Correntes.";
            }
        }

        protected void Ok_Click(object sender, EventArgs e)
        {
            if (lstContaBancaria.SelectedIndex == -1)
            {
                Master.ShowMessage("Favor Selecionar Conta(s) Bancaria(s)");
                return;
            }

            Session["cldDe"] = cldDe.SelectedDate;
            Session["cldAte"] = cldAte.SelectedDate;

            List<int> contaBancaria = new List<int>();
            foreach (ListItem item in lstContaBancaria.Items)
                if (item.Selected)
                    contaBancaria.Add(item.Value.ToInt());

            Session["lstContaBancaria"] = contaBancaria;
            Session["Procedure"] = lstTipoData.SelectedValue;

            string script = "abrir_popup('ExtratoBancario/ExtratoBancario.aspx','Receita',800,600);";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        protected void btnGerarDiario_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            Status status = new Status();
            Session["Status"] = status;

            tmrTempo.Interval = 2000;
            Session.Add("Parado", "0");
            tmrTempo.Enabled = true;
            System.Threading.Thread Th = new System.Threading.Thread(MontaGrid);

            Session["Th"] = Th;
            Th.Start();
        }

        private void MontaGrid()
        {
            Status status;
            if (Session["Status"] == null)
                status = new Status();
            else
                status = (Status)Session["Status"];

            string IdDadosBancario = string.Empty;
            foreach (ListItem item in lstContaBancaria.Items)
                if (item.Selected)
                    IdDadosBancario += item.Value + ",";


            int qtdDias = Convert.ToInt32(((TimeSpan)cldAte.SelectedDate.Subtract(cldDe.SelectedDate)).TotalDays);
            status.Ate = qtdDias;

            StringBuilder SbDiario = new StringBuilder();
            StringBuilder SbExtrato = new StringBuilder();
            decimal totSaldoInicial = 0, totEntradas = 0, totSaidas = 0;
            for (int iDia = 0; iDia <= qtdDias; iDia++)
            {
                decimal subTotSaldoInicial = 0, subTotEntradas = 0, subTotSaidas = 0;

                status.De = iDia;
                Session["Status"] = status;

                DateTime dataAux = cldDe.SelectedDate.AddDays(iDia);

                List<DTO.ExtratoBancario> extratosBancarios = new BLL.ExtratoBancario().Select(dataAux, dataAux, IdDadosBancario.Substring(0, IdDadosBancario.LastIndexOf(',')), lstTipoData.SelectedValue);
                var saldoInicia = extratosBancarios.Where(c => c.Tipo.Equals(0)).ToList();

                SbExtrato.AppendLine("Saldo Inicial");
                foreach (var item in saldoInicia)
                {
                    SbExtrato.AppendFormat("{0};{1};{2};{3}", item.Conta, item.Data, item.Saldo, item.Descricao.Replace("\r", " ").Replace("\n", " "));
                    SbExtrato.AppendLine();
                    subTotSaldoInicial += item.Saldo;
                }
                totSaldoInicial += subTotSaldoInicial;
                SbExtrato.AppendLine();
                var entrada = extratosBancarios.Where(c => c.Tipo.Equals(1)).ToList();
                SbExtrato.AppendLine("Entradas");
                foreach (var item in entrada)
                {
                    SbExtrato.AppendFormat("{0};{1};{2};{3}", item.Conta, item.Data, item.Credito, item.Descricao.Replace("\r", " ").Replace("\n", " "));
                    SbExtrato.AppendLine();
                    subTotEntradas += item.Credito;
                }
                totEntradas += subTotSaidas;
                SbExtrato.AppendLine();
                var saida = extratosBancarios.Where(c => c.Tipo.Equals(2)).ToList();
                SbExtrato.AppendLine("Saidas");
                foreach (var item in saida)
                {
                    SbExtrato.AppendFormat("{0};{1};{2};{3}", item.Conta, item.Data, item.Debito, item.Descricao.Replace("\r", " ").Replace("\n", " "));
                    SbExtrato.AppendLine();
                    subTotSaidas += item.Debito;
                }
                totSaidas += subTotSaidas;
                SbExtrato.AppendLine();


                SbDiario.AppendLine(string.Format("{0};{1};{2};{3};{4}", dataAux.Date.ToString("dd/MM/yyyy"), subTotSaldoInicial, subTotEntradas, subTotSaidas, subTotSaldoInicial + subTotEntradas + subTotSaidas));
            }
            SbDiario.AppendLine(string.Format("{0};{1};{2};{3}", "Total", "", totEntradas, totSaidas, ""));

            Session["Diario"] = SbDiario.ToString();// fechamentoscarteiras;
            Session["Extrato"] = SbExtrato.ToString();
            Session["Status"] = null;
        }

        private class Status
        {
            public int De { get; set; }

            public int Ate { get; set; }
        }

        protected void tmrTempo_Tick(object sender, EventArgs e)
        {
            if (Session["Status"] != null)
            {
                btnGerarDiario.Visible = false;
                Status status = (Status)Session["Status"];
                //Session.Add("Status", Math.Round(((decimal)i / (decimal)TablePesquisaEMail.Rows.Count * 100), 2));
                lblTempo.Text = string.Format("Processado {0} de {1} carteiras", status.De.ToString(), status.Ate.ToString());

                pnlStatus.Width = Convert.ToInt16((Convert.ToDecimal(status.De) / Convert.ToDecimal(status.Ate)) * 100) * 5;
            }
            else
            {
                tmrTempo.Enabled = false;
                //gdvFechamento.DataSource = ((List<Fechamentocarteira>)Session["Diario"]).OrderBy(c => c.Carteira);
                //gdvFechamento.DataBind();

                using (StreamWriter writer = new StreamWriter("teste.csv", false, Encoding.GetEncoding("ISO-8859-1")))
                {
                    writer.WriteLine("Data;Saldo Inicial;Entradas;Saidas;Totais");
                    writer.WriteLine(Session["Diario"].ToString());
                    writer.WriteLine("Dados Bancario;Data;Credito/ Debito;Descrição");

                    writer.WriteLine(Session["Extrato"].ToString());
                }
                lblTempo.Visible = false;
                Panel1.Visible = false;
            }
        }
    }
}