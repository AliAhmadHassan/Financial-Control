using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.Consolidado
{
    public partial class Consolidado : System.Web.UI.Page
    {
        List<string> MesesReferencias = new List<string>();
        int IdCarteira = 0;
        int TipoReceita = 0;
        int TipoDespesa = 0;
        int Dedutivel = 0;
        DateTime DtDe;
        DateTime DtAte;

        List<List<DTO.Consolidado>> consolidados = new List<List<DTO.Consolidado>>();
        List<decimal> NaoOperacional = new List<decimal>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DtDe = Convert.ToDateTime(Session["De"]);
                DtAte = Convert.ToDateTime(Session["Ate"]);
                IdCarteira = Session["IdCarteira"].ToString().ToInt();
                TipoReceita = Session["TipoReceita"].ToString().ToInt();
                TipoDespesa = Session["TipoDespesa"].ToString().ToInt();
                Dedutivel = Session["Dedutivel"].ToString().ToInt();



                Session.Remove("IdCarteira");
                Session.Remove("De");
                Session.Remove("Ate");
                Session.Remove("TipoReceita");
                Session.Remove("TipoDespesa");
                Session.Remove("Dedutivel");

                string IdDadosBancario = string.Empty;

                foreach (int aux in (List<int>)Session["lstContaBancaria"])
                {
                    IdDadosBancario += aux + ",";
                }


                for (int i = 0; i <= DtAte.Subtract(DtDe).Days; i++)
                {
                    DateTime dtref = DtDe.AddDays(i);

                    string MesRef = string.Format("{0}/{1}", MesReferente(dtref.Month), dtref.Year.ToString("0000"));

                    if (!MesesReferencias.Contains(MesRef))
                    {
                        MesesReferencias.Add(MesRef);
                    }
                }


                for (int i = 0; i < MesesReferencias.Count; i++)
                {
                    string mesReferencia = MesesReferencias[i];
                    int Mes = MesReferenteIndexOf(mesReferencia.Split('/')[0]);
                    int Ano = mesReferencia.Split('/')[1].ToInt();

                    DateTime FinalMes = DateTime.Parse(string.Format("01/{0}/{1}", Mes, Ano)).AddMonths(1).AddDays(-1);

                    if (i == 0)
                    {
                        if (DtAte < FinalMes)
                        {
                            consolidados.Add(new BLL.Consolidado().Select(DtDe, DtAte, IdCarteira, Dedutivel, TipoReceita, TipoDespesa, IdDadosBancario));
                        }
                        else
                        {
                            consolidados.Add(new BLL.Consolidado().Select(DtDe, FinalMes, IdCarteira, Dedutivel, TipoReceita, TipoDespesa, IdDadosBancario));
                        }
                    }
                    else if (i == MesesReferencias.Count - 1)
                    {
                        consolidados.Add(new BLL.Consolidado().Select(DtAte.AddDays(-DtAte.Day + 1), DtAte, IdCarteira, Dedutivel, TipoReceita, TipoDespesa, IdDadosBancario));
                    }
                    else
                    {
                        consolidados.Add(new BLL.Consolidado().Select(FinalMes.AddDays(-FinalMes.Day + 1), FinalMes, IdCarteira, Dedutivel, TipoReceita, TipoDespesa, IdDadosBancario));
                    }
                }

                MontaTela();
            }
        }

        private void MontaTela()
        {
            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
            tree.DataSource = new BLL.Segmento().SelectIdentado();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            TreeNode treeNode = tree.DataBind();

            StringBuilder html = new StringBuilder();
            #region Titulo
            html.AppendLine(string.Format(@"
<table width='{0}px'>
    <tr>
        <td width='33%'><img  src='../../../../Imagens/Logo%20Orc.jpg'  style='width:200px' /></td>
        <td width='33%'><br/><b>Relatorio Consolidado</b><br></td>
        <td width='33%' style='text-align:right;'>
            Referente a Carteira: {2}<br/><span style='font-size:small;'>De {3} até {4}</span>
        </td>
    </tr>
", 620 + 100 * MesesReferencias.Count, DateTime.Now.ToString("D"), new BLL.Carteira().SelectPelaPK(IdCarteira).Descricao, DtDe.ToString("dd/MM/yyyy"), DtAte.ToString("dd/MM/yyyy")));
            html.AppendLine(string.Format(@"<tr></tr>", 620 + 150 * MesesReferencias.Count));


            #endregion

            html.AppendLine(string.Format(@"<table width='{0}px'>", 620 + 150 * MesesReferencias.Count));
            #region Cabeçalho
            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Black; color:White;'><b>{0}</b></td>", "Contas"));
            foreach (string mesReferencia in MesesReferencias)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:center; background-color:Black; color:White;'><b>{0}</b></td>", mesReferencia));

            html.AppendLine("<td style='border-bottom:1px dotted black; text-align:center; background-color:Black; color:White;'>&#916;H</td>");
            html.AppendLine("<td style='border-bottom:1px dotted black; text-align:center; background-color:Black; color:White;'>&#916;V</td>");
            html.AppendLine("</tr>");

            
            #endregion

            #region Detail
            Aux(html, treeNode);

            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>{0}</b></td>", treeNode.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;")));
            for (int i = 0; i < MesesReferencias.Count; i++)
            {
                decimal Valor = consolidados[i].Where(c=>c.Tipo != "Não Operacional").Where(x=>!x.Id.Equals(187)).Sum(w => w.Valor);
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{1}</b></td>", treeNode.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;"), Valor.ToString("C")));
            }
            html.AppendLine("<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'></td><td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'></td>");
            html.AppendLine("</tr>");

            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>{0}</b></td>", "Geral com Retiradas da Presidência"));
            for (int i = 0; i < MesesReferencias.Count; i++)
            {
                decimal Valor = consolidados[i].Where(c => c.Tipo != "Não Operacional").Sum(w => w.Valor);
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{1}</b></td>", treeNode.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;"), Valor.ToString("C")));
            }
            html.AppendLine("<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'></td><td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'></td>");
            html.AppendLine("</tr>");
            #endregion
            html.AppendLine(@"</table>");

            TabelaDiretoIndireto(html);

            LiteralTabela.Text = html.ToString();
        }

        private void TabelaDiretoIndireto(StringBuilder html)
        {
            html.AppendLine(string.Format(@"<br /><br /><table width='{0}px'>", 620 + 150 * MesesReferencias.Count));
            #region Cabeçalho
            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Black; color:White;'><b>{0}</b></td>", "Contas"));
            foreach (string mesReferencia in MesesReferencias)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:center; background-color:Black; color:White;'><b>{0}</b></td>", mesReferencia));
            html.AppendLine("</tr>");
            #endregion

            #region Detail
            decimal[] ReceitaBruta = LinhaDiretaIndireta(html, "Receita Bruta");
            decimal[] Imposto = LinhaDiretaIndireta(html, "Imposto");

            #region Receita Liquida
            html.AppendLine(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>Receita Liquida</b></td>");
            for (int i = 0; i < MesesReferencias.Count; i++)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{0}</b></td>", (ReceitaBruta[i] + Imposto[i]).ToString("C")));
            #endregion

            decimal[] CustoFixoVariado = LinhaDiretaIndireta(html, "Custo Fixo e Variado");

            #region Despesa Oper. / Receita Bruta
            html.AppendLine(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>Despesas Oper. / Receita Bruta</b></td>");
            for (int i = 0; i < MesesReferencias.Count; i++)
                if (ReceitaBruta[i] != 0)
                    html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{0}%</b></td>", Math.Round((-CustoFixoVariado[i] / ReceitaBruta[i]) * 100, 2).ToString("0.00")));
            #endregion

            #region Margem Contribuicao
            html.AppendLine(@"<tr><td style='border-bottom:1px dotted black; background-color:yellow;'><b>% Margem de Contribuição</b></td>");
            for (int i = 0; i < MesesReferencias.Count; i++)
                if (ReceitaBruta[i] != 0)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:yellow;'><b>{0}%</b></td>", (100 - Math.Round((-CustoFixoVariado[i] / ReceitaBruta[i]) * 100, 2)).ToString("0.00")));
            #endregion

            decimal[] NaoOperacional = LinhaDiretaIndireta(html, "Não Operacional");

            #region Despesa NO / Receita Bruta
            html.AppendLine(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>Despesa N.O. / Receita Bruta</b></td>");
            for (int i = 0; i < MesesReferencias.Count; i++)
                if (ReceitaBruta[i] != 0)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{0}</b></td>", Math.Round((NaoOperacional[i] / ReceitaBruta[i]) * 100, 2).ToString("0.00")));
            #endregion

            #region Lucro Liquido
            decimal[] LucroLiquido = new decimal[MesesReferencias.Count];
            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Black; color:White;'><b>{0}</b></td>", "Lucro Liquido"));
            for (int i = 0; i < MesesReferencias.Count; i++)
            {
                LucroLiquido[i] = consolidados[i].Where(c => !c.Id.Equals(187)).Sum(w => w.Valor);
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Black; color:White;'><b>{0}</b></td>", LucroLiquido[i].ToString("C")));
            }
            #endregion

            #region % L / (P)
            #region Despesa NO / Receita Bruta
            html.AppendLine(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>% L / (P)</b></td>");
            for (int i = 0; i < MesesReferencias.Count; i++)
                if (ReceitaBruta[i] != 0)
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;'><b>{0}%</b></td>", Math.Round((LucroLiquido[i] / ReceitaBruta[i]) * 100, 2).ToString("0.00")));
            #endregion
            #endregion

            html.AppendLine("</tr>");
            #endregion

            html.AppendLine(@"</table>");
        }

        private decimal[] LinhaDiretaIndireta(StringBuilder html, string tipo)
        {
            decimal[] Valor = new decimal[MesesReferencias.Count];

            html.AppendLine(string.Format(@"<tr><td style='border-bottom:1px dotted black; background-color:Silver;'><b>{0}</b></td>", tipo));
            for (int i = 0; i < MesesReferencias.Count; i++)
            {
                var SubTotal = consolidados[i].Where(c => c.Tipo.Equals(tipo)).ToList();
                Valor[i] = SubTotal.Where(c=> !c.Id.Equals(187)).Sum(w => w.Valor);
                html.AppendLine(string.Format(@"<td style='border-bottom:1px dotted black; text-align:right; background-color:Silver;{1}'><b>{0}</b></td>", Valor[i].ToString("C"), Valor[i] < 0 ? "color:Red;" : ""));
            }
            html.AppendLine("</tr>");

            return Valor;
        }

        private decimal ConsultaValor(int p, int MesReferencia)
        {
            return consolidados[MesReferencia].Where(c => c.Id.Equals(p)).FirstOrDefault().Valor;
        }

        private void Aux(StringBuilder html, TreeNode treenode, decimal Receita = 0)
        {

            foreach (TreeNode node in treenode.ChildNodes)
            {
                string TipoReceitaDespesa = "";
                //string TipoReceitaDespesa = consolidados[0].Where(c => c.Id.Equals(node.Value.ToInt())).FirstOrDefault().Tipo;
                //switch (TipoReceitaDespesa)
                //{
                //    case "Receita Direta": TipoReceitaDespesa = "D"; break;
                //    case "Receita Indireta": TipoReceitaDespesa = "I"; break;
                //    case "Despesa Direta": TipoReceitaDespesa = "D"; break;
                //    case "Despesa Indireta": TipoReceitaDespesa = "I"; break;
                //}

                html.AppendLine(string.Format(@"
<tr>
    <td style='border-bottom:1px dotted black;{1}'>{0}</td>", TipoReceitaDespesa + node.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;"), node.ChildNodes.Count > 0 ? "font-weight:bold;" : ""));

                for (int i = 0; i < MesesReferencias.Count; i++)
                {
                    decimal Valor = ConsultaValor(node.Value.ToInt(), i) + ValorSubTotal(node, 0, i);
                    html.AppendLine(string.Format(@"
    <td style='border-bottom:1px dotted black; text-align:right;{1}{2}'>{0}</td>
",
          Valor.ToString("C"),
          node.ChildNodes.Count > 0 ? "font-weight:bold;" : "",
          Valor < 0 ? "color:Red;" : ""));

                    if (i == MesesReferencias.Count - 1)
                        if (node.Value.ToInt() == 2)
                            Receita = Valor;
                }


                #region Delta V e H
                decimal ValorMes0 = ConsultaValor(node.Value.ToInt(), 0) + ValorSubTotal(node, 0, 0);
                decimal ValorMes1 = ConsultaValor(node.Value.ToInt(), MesesReferencias.Count-1) + ValorSubTotal(node, 0, MesesReferencias.Count-1);
                decimal DeltaH = ValorMes0 != 0 ? Math.Round((decimal)ValorMes1 / (decimal)ValorMes0, 4) * 100 : 0;
                decimal DeltaV = Receita != 0 ? Math.Round((decimal)ValorMes1 / (decimal)Receita, 4) * 100 : 0;
                html.AppendLine(string.Format("<td style='border-left:1px dotted black; border-bottom:1px dotted black; text-align:right;{1}{2}; background-color:Silver;'>{0}%</td>", DeltaH.ToString("0.00"), node.ChildNodes.Count > 0 ? "font-weight:bold;" : "", ValorMes1 < 0 ? "color:Red;" : ""));
                html.AppendLine(string.Format("<td style='border-left:1px dotted black; border-bottom:1px dotted black; text-align:right;{1}{2}; background-color:Silver;'>{0}%</td>", DeltaV.ToString("0.00"), node.ChildNodes.Count > 0 ? "font-weight:bold;" : "", ValorMes1 < 0 ? "color:Red;" : ""));
                #endregion
                html.AppendLine("</tr>");
                if (node.ChildNodes.Count > 0)
                    Aux(html, node, Receita);
            }
        }

        private decimal ValorSubTotal(TreeNode treenode, decimal valor, int mesReferencia)
        {
            decimal Total = valor;
            foreach (TreeNode node in treenode.ChildNodes)
            {
                Total += consolidados[mesReferencia].Where(c => c.Id.Equals(node.Value.ToInt())).FirstOrDefault().Valor;
                Total += ValorSubTotal(node, valor, mesReferencia);
            }
            return Total;
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

        public static int MesReferenteIndexOf(string MesReferencia)
        {
            int sMes = 0;
            if (MesReferencia == "Janeiro")
                sMes = 1;
            if (MesReferencia == "Fevereiro")
                sMes = 2;
            if (MesReferencia == "Março")
                sMes = 3;
            if (MesReferencia == "Abril")
                sMes = 4;
            if (MesReferencia == "Maio")
                sMes = 5;
            if (MesReferencia == "Junho")
                sMes = 6;
            if (MesReferencia == "Julho")
                sMes = 7;
            if (MesReferencia == "Agosto")
                sMes = 8;
            if (MesReferencia == "Setembro")
                sMes = 9;
            if (MesReferencia == "Outubro")
                sMes = 10;
            if (MesReferencia == "Novembro")
                sMes = 11;
            if (MesReferencia == "Dezembro")
                sMes = 12;

            return sMes;
        }
    }
}