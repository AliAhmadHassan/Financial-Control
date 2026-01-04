using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;
using System.Text;
using System.Drawing;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.Fechamento
{
    public partial class Fechamento : System.Web.UI.Page
    {
        string MesReferencia = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void MontaGrid()
        {
            Status status;
            if (Session["Status"] == null)
                status = new Status();
            else
                status = (Status)Session["Status"];

            int Mes = MesReferencia.Split('/')[0].ToInt(), Ano = MesReferencia.Split('/')[1].ToInt();

            DateTime DtDe = Convert.ToDateTime(string.Format("{1}-{0}-01", Mes, Ano));
            DateTime DtAte = DtDe.AddMonths(1).AddDays(-1);


            StringBuilder IdDadosBancario = new StringBuilder();
            foreach (DTO.DadosBancario dadosBancario in new BLL.DadosBancario().Select())
                IdDadosBancario.AppendFormat("{0}, ", dadosBancario.Id);


            List<DTO.Carteira> carteiras = new BLL.Carteira().Select().Where(c => c.Tipo.Equals(2)).ToList();
            List<Fechamentocarteira> fechamentoscarteiras = new List<Fechamentocarteira>();

            status.Ate = carteiras.Count();
            for (int i = 0; i < carteiras.Count; i++)
            {
                status.De = i;
                Session["Status"] = status;

                ControleFinanceiro.DTO.Carteira carteira = carteiras[i];

                if (new BLL.Carteira().SelectPeloIdPai(carteira.Id).Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine(carteira.Id);

                    List<DTO.Consolidado> consolidado = new BLL.Consolidado().Select(DtDe, DtAte, carteira.Id, -1, 0, 2, IdDadosBancario.ToString());

                    Fechamentocarteira fechamentocarteira = new Fechamentocarteira();

                    fechamentocarteira.Carteira = string.Format("{0}/{1}", new BLL.Carteira().SelectPelaPK(carteira.IdPai).Descricao, carteira.Descricao);
                    fechamentocarteira.ReceitaBruta = consolidado.Where(c => !c.Id.Equals(187)).Where(w => w.Tipo.Equals("Receita Bruta")).Sum(c => c.Valor);
                    fechamentocarteira.Imposto = consolidado.Where(c => !c.Id.Equals(187)).Where(w => w.Tipo.Equals("Imposto")).Sum(c => c.Valor);
                    fechamentocarteira.ReceitaLiquida = fechamentocarteira.ReceitaBruta + fechamentocarteira.Imposto;
                    fechamentocarteira.CustoFixoVariado = consolidado.Where(c => !c.Id.Equals(187)).Where(w => w.Tipo.Equals("Custo Fixo e Variado")).Sum(c => c.Valor);
                    fechamentocarteira.NaoOperacional = consolidado.Where(c => !c.Id.Equals(187)).Where(w => w.Tipo.Equals("Não Operacional")).Sum(c => c.Valor);
                    fechamentocarteira.LucroLiquido = consolidado.Where(c => !c.Id.Equals(187)).Sum(c => c.Valor);

                    if (fechamentocarteira.ReceitaBruta > 0)
                    {
                        fechamentocarteira.DespesasOper_ReceitaBruta = string.Format("{0} %", Math.Round((-fechamentocarteira.CustoFixoVariado / fechamentocarteira.ReceitaBruta) * 100, 2).ToString("0.00"));
                        fechamentocarteira.MargemContribuicao = string.Format("{0} %", Math.Round(100 - (-fechamentocarteira.CustoFixoVariado / fechamentocarteira.ReceitaBruta) * 100, 2).ToString("0.00"));
                        fechamentocarteira.DespesaNO_ReceitaBruta = string.Format("{0} %", Math.Round((fechamentocarteira.NaoOperacional / fechamentocarteira.ReceitaBruta) * 100, 2).ToString("0.00"));
                        fechamentocarteira.L_P = string.Format("{0} %", Math.Round((fechamentocarteira.LucroLiquido / fechamentocarteira.ReceitaBruta) * 100, 2).ToString("0.00"));
                    }
                    fechamentoscarteiras.Add(fechamentocarteira);
                }
            }

            Session["fechamentoscarteiras"] = fechamentoscarteiras;
            Session["Status"] = null;
        }
        private class Fechamentocarteira
        {
            public string Carteira { get; set; }
            public decimal ReceitaBruta { get; set; }
            public decimal Imposto { get; set; }
            public decimal ReceitaLiquida { get; set; }
            public decimal CustoFixoVariado { get; set; }
            public string DespesasOper_ReceitaBruta { get; set; }
            public string MargemContribuicao { get; set; }
            public decimal NaoOperacional { get; set; }
            public string DespesaNO_ReceitaBruta { get; set; }
            public decimal LucroLiquido { get; set; }
            public string L_P { get; set; }
        }

        protected void gdvFechamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //0<asp:BoundField DataField="Carteira" HeaderText="Carteira" />
                //1<asp:BoundField DataField="ReceitaBruta" HeaderText="Receita Bruta" DataFormatString="{0:C2}" />
                //2<asp:BoundField DataField="Imposto" HeaderText="Impostos" DataFormatString="{0:C2}" />
                //3<asp:BoundField DataField="ReceitaLiquida" HeaderText="Receita Liquida" DataFormatString="{0:C2}" />
                //4<asp:BoundField DataField="CustoFixoVariado" HeaderText="Gastos Operacionais" DataFormatString="{0:C2}" />
                //5<asp:BoundField DataField="DespesasOper_ReceitaBruta" HeaderText="Gastos Oper. / Receita Bruta" />
                //6<asp:BoundField DataField="MargemContribuicao" HeaderText="% Margem Contribuição" />
                //7<asp:BoundField DataField="NaoOperacional" HeaderText="Não Operacional" DataFormatString="{0:C2}" />
                //8<asp:BoundField DataField="DespesaNO_ReceitaBruta" HeaderText="Despesa N.O. / Receita Bruta" />
                //9<asp:BoundField DataField="LucroLiquido" HeaderText="Lucro Liquido" DataFormatString="{0:C2}" />
                //10<asp:BoundField DataField="L_P" HeaderText="% L / (P)" />


                if (e.Row.Cells[1].Text.Contains('-')) e.Row.Cells[1].ForeColor = Color.Red;
                if (e.Row.Cells[2].Text.Contains('-')) e.Row.Cells[2].ForeColor = Color.Red;
                if (e.Row.Cells[3].Text.Contains('-')) e.Row.Cells[3].ForeColor = Color.Red;
                if (e.Row.Cells[4].Text.Contains('-')) e.Row.Cells[4].ForeColor = Color.Red;
                if (e.Row.Cells[7].Text.Contains('-')) e.Row.Cells[7].ForeColor = Color.Red;
                if (e.Row.Cells[9].Text.Contains('-')) e.Row.Cells[9].ForeColor = Color.Red;

                if (e.Row.Cells[1].Text.Contains("R$ 0,00"))
                {
                    if (e.Row.Cells[5].Text.Contains('-')) e.Row.Cells[5].ForeColor = Color.Red;
                    if (e.Row.Cells[6].Text.Contains('-')) e.Row.Cells[6].ForeColor = Color.Red;
                    if (e.Row.Cells[8].Text.Contains('-')) e.Row.Cells[8].ForeColor = Color.Red;
                    if (e.Row.Cells[10].Text.Contains('-')) e.Row.Cells[10].ForeColor = Color.Red;
                }
                e.Row.Cells[6].BackColor = Color.Yellow;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Status status = new Status();
            Session["Emailstatus"] = status;

            tmrTempo.Interval = 2000;
            Session.Add("Parado", "0");
            tmrTempo.Enabled = true;
            MesReferencia = Request.QueryString.Get("MesReferencia");
            System.Threading.Thread Th = new System.Threading.Thread(MontaGrid);

            Session["Th"] = Th;
            Th.Start();

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
                Button1.Visible = false;
                Status status = (Status)Session["Status"];
                //Session.Add("Status", Math.Round(((decimal)i / (decimal)TablePesquisaEMail.Rows.Count * 100), 2));
                lblTempo.Text = string.Format("Processado {0} de {1} carteiras", status.De.ToString(), status.Ate.ToString());

                pnlStatus.Width = Convert.ToInt16((Convert.ToDecimal(status.De) / Convert.ToDecimal(status.Ate)) * 100)*5;
            }
            else
            {
                tmrTempo.Enabled = false;
                gdvFechamento.DataSource = ((List<Fechamentocarteira>)Session["fechamentoscarteiras"]).OrderBy(c=>c.Carteira);
                gdvFechamento.DataBind();
                lblTempo.Visible = false;
                Panel1.Visible = false;
            }
        }
    }
}