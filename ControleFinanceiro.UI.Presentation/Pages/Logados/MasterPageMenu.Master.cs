using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados
{
    public partial class MasterPageMenu : System.Web.UI.MasterPage
    {
        //Seta o nome da página
        public string NomeAplicacao
        {
            set { lblNomePagina.Text = value; }
        }

        //Seta a descricao da página
        public string DescricaoAplicacao
        {
            set { lblDescricaoPagina.Text = value; }
        }

        public void ShowMessage(string Texto)
        {
            ShowMessage("Aviso!", Texto);
        }
        public void ShowMessage(string Titulo, string Texto)
        {
            MensagemOK1.ShowMessage(Titulo, Texto);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                MontaMenu();
            //}
        }

        private void MontaMenu()
        {
            ltlMenuAdministrador.Text = string.Empty;
            ltlMenuParqueGrafico.Text = string.Empty;
            ltlMenuFinanceiro.Text = string.Empty;
            ltlMenuTelefonia.Text = string.Empty;
            ltlMenuRecursosHumanos.Text = string.Empty;
            ltlMenuRelatorios.Text = string.Empty;
            
            
            List<DTO.Menu> menus = new BLL.Menu().SelectPelaIdUsuario(((DTO.Usuario)Session["Usuario"]).Id);

            StringBuilder SbMenu = new StringBuilder();

            SbMenu.AppendLine("<table>");
            foreach(DTO.Menu menu in menus.OrderBy(c=> c.IdPai).ToList())
            {
                string Item = string.Format(@"<div style='float:left; width:90px; text-align:center; height: 100px'><a href='{2}'><img src='{0}'/><br/>{1}</a></div>", ResolveClientUrl("~/Imagens/" + Convert.ToString(menu.Imagem)), menu.Descricao, ResolveUrl("~/Pages/Logados/" + Convert.ToString(menu.URL)));

                switch(menu.IdPai)
                {
                    case 1: //Adminisrador
                        ltlMenuAdministrador.Text += Item;
                        break;

                    case 5: //Parque Grafico
                        ltlMenuParqueGrafico.Text += Item;
                        break;

                    case 9: //Financeiro
                        ltlMenuFinanceiro.Text += Item;
                        break;

                    case 11: //Telefonia
                        ltlMenuTelefonia.Text += Item;
                        break;

                    case 15: //Recursos Humenos
                        ltlMenuRecursosHumanos.Text += Item;
                        break;

                    case 18: //Relatorios
                        ltlMenuRelatorios.Text += Item;
                        break;
                }

                //if (string.IsNullOrEmpty(menu.Imagem))
                //{
                //    SbMenu.AppendLine(string.Format("</tr></table><br/><span style='text-align: center; color:gray'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<b>{0}</b></span><table style='padding-left:25px; width:230px;'><tr>", menu.Descricao));
                //    count = 0;
                //}
                //else
                //{
                //    SbMenu.AppendLine(string.Format("<td style='text-align: center; color:black; font-size:12px;' width='115px'><a href='{2}'><img src='{0}' /><br/>{1}</a></td>", ResolveClientUrl("~/Imagens/" + Convert.ToString(menu.Imagem)), menu.Descricao, ResolveUrl("~/Pages/Logados/" + Convert.ToString(menu.URL))));
                //    count++;
                //}

                //if (count % 2 == 0)
                //    SbMenu.AppendLine("</tr><tr>");

            }
            SbMenu.AppendLine("</table>");

            //ltlMenu.Text = SbMenu.ToString();

        }
    }
}