using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Orcamento
{
    public partial class Orcamento : System.Web.UI.Page
    {
        List<DTO.Segmento> segmentos = null;
        List<DTO.SegmentoOrcamentoUnitario> segmentoOrcamentosUnitarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTelaSegmento();
            }
        }

        private void MontaTelaSegmento()
        {
            segmentoOrcamentosUnitarios = new BLL.SegmentoOrcamentoUnitario().Select();
            segmentos = new BLL.Segmento().SelectIdentado();

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
            tree.DataSource = segmentos;
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";
            TreeNode treeNode = tree.DataBind();

            StringBuilder html = new StringBuilder();
            html.AppendLine("<Table>");
            html.AppendLine("   <tr>");
            html.AppendLine(string.Format("       <th>{0}</th>", "Segmento"));
            for (int i = DateTime.Today.Month + 1; i <= 12; i++)
            {
                html.AppendLine(string.Format("       <th>{0}</th>", Common.intToMes(i)));
            }
            html.AppendLine("   </tr>");

            Aux(html, treeNode);
            html.AppendLine("</Table>");



            ltlSegmento.Text = html.ToString();
        }

        private void Aux(StringBuilder html, TreeNode treenode)
        {

            foreach (TreeNode node in treenode.ChildNodes)
            {
                string Descricao = node.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;");
                bool TemFilhos = node.ChildNodes.Count > 0 ? true : false;


                html.AppendLine("   <tr>");
                if (TemFilhos)
                {
                    html.AppendLine(string.Format("       <td style='border-bottom:1px dotted black; background-color:#267597;'>{0}</td>", Descricao));
                    for (int i = DateTime.Today.Month + 1; i <= 12; i++)
                        html.AppendLine(string.Format("       <td style='border-bottom:1px dotted black; background-color:#267597;'></td>"));
                }
                else
                {
                    html.AppendLine(string.Format("       <td style='border-bottom:1px dotted black;'>{0}</td>", Descricao));
                    for (int i = DateTime.Today.Month + 1; i <= 12; i++)
                    {
                        html.AppendLine("       <td style='border-bottom:1px dotted black;'>");
                        if (segmentoOrcamentosUnitarios.Where(c=> c.IdSegmento.Equals(node.Value.ToInt())).Count() > 0)
                        {
                            html.AppendLine(string.Format("         <input id='lbl{0}_{1}' name='Tb{0}_{1}' type='text' style='width:100px; border: none; color:white; background-color:#004C66;' readonly  />", node.Value, i.ToString()));
                            html.AppendLine(string.Format("         <br/><input id='btn{0}_{1}' value='Calcular' type='button'/>", node.Value, i.ToString()));
                            html.AppendLine(string.Format("         <br/><input id='hdf{0}_{1}' value='' type='text'/>", node.Value, i.ToString())); //hidden

                            html.AppendLine("        <script>");
                            html.AppendLine("            $(\"#btn" + node.Value + "_" + i.ToString() + "\").click(function (e) {");
                            html.AppendLine("                var esquerda = $(\"#lbl" + node.Value + "_" + i.ToString() + "\").offset().left + 20;");
                            html.AppendLine("                var emCima = $(\"#lbl" + node.Value + "_" + i.ToString() + "\").offset().top;");
                            html.AppendLine("                $(\"#TempTela\").remove();");
                            html.Append("                $(\"#Content\").append(\"<div Id='TempTela' style='border: 1px solid black; position: absolute; top: \" + emCima + \"px; left:\" + esquerda  + \"px; background-color: white; color:black'>");

                            html.Append("<table>");
                            html.Append("<tr><th style='border:1px dotted silver;'>Descrição</th><th style='border:1px dotted silver;'>Valor</th><th style='border:1px dotted silver;'> Qtd.</th></tr>");
                            foreach (DTO.SegmentoOrcamentoUnitario item in segmentoOrcamentosUnitarios.Where(c => c.IdSegmento.Equals(node.Value.ToInt())))
                            {
                                html.Append("<tr><td style='border:1px dotted silver;'>" + item.Descricao + "</td><td style='border:1px dotted silver;'>(" + item.Valor.ToString("c2") + ")</td><td style='border:1px dotted silver;'> <input id='lblUnitario' class='lblUnitario' style='width:50px;' valorUnitario='" + item.Valor.ToString("0.00").Replace(",", ".") + "' codUnitario='" + item.Id.ToString() + "' value='0' type='text'></td></tr>");
                            }
                            html.Append("</table>");
                            html.Append("<input type='button' id='btnCalcular" + node.Value + "_" + i.ToString() + "' onclick=\\\"var total = 0.0; var escolha = ''; $('.lblUnitario').each(function () { total = parseFloat(total) + parseFloat($(this).val()) * parseFloat($(this).attr('valorUnitario')); escolha = escolha + $(this).attr('codUnitario') + '|' + $(this).val() + '|' + $(this).attr('valorUnitario') + ';'; }); $('#lbl" + node.Value + "_" + i.ToString() + "').val(total.toFixed(2));  $('#hdf" + node.Value + "_" + i.ToString() + "').val(escolha);   $('#TempTela').remove();\\\" value='Ok'/><input type='button' id='btnCalcularCalcelar'  onclick=\\\"script:$('#TempTela').remove();\\\" value='Cancelar'/>");
                            html.AppendLine("                </div>\");");
                            html.AppendLine("            });");
                            html.AppendLine("        </script>");
                        }
                        else
                            html.AppendLine(string.Format("         <input id='lbl{0}_{1}' name='Tb{0}_{1}' type='text' style='width:100px' />", node.Value, i.ToString()));

                        html.AppendLine("       </td>");
                    }
                }
                html.AppendLine("   </tr>");

                if (node.ChildNodes.Count > 0)
                    Aux(html, node);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            segmentoOrcamentosUnitarios = new BLL.SegmentoOrcamentoUnitario().Select();
            segmentos = new BLL.Segmento().SelectIdentado();

            foreach (DTO.Segmento segmento in segmentos)
            {

            }
        }
    }
}