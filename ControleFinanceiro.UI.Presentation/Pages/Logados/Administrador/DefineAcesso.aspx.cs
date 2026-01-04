using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class DefineAcesso : System.Web.UI.Page
    {
        List<DTO.Menu> menus = new List<DTO.Menu>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaMenu();
            }            
        }

        private void MontaMenu()
        {
            menus = new BLL.Menu().SelectPelaIdUsuario(Request.QueryString.Get("Usuario").ToInt());
            gdvAcesso.DataSource = new BLL.Menu().SelectPelaIdUsuario(((DTO.Usuario)Session["Usuario"]).Id);
            gdvAcesso.DataBind();
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DTO.UsuarioMenu> usuarioMenus = new List<DTO.UsuarioMenu>();

                foreach (GridViewRow row in gdvAcesso.Rows)
                {
                    CheckBox ch = (CheckBox)row.FindControl("CbAcesso");
                    if (ch.Checked)
                    {
                        DTO.UsuarioMenu usuarioMenu = new DTO.UsuarioMenu();
                        usuarioMenu.IdUsuario = Request.QueryString.Get("Usuario").ToInt();
                        usuarioMenu.IdMenu = row.Cells[3].Text.ToInt();
                        usuarioMenus.Add(usuarioMenu);
                    }
                }

                if (usuarioMenus.Count > 0)
                    new BLL.UsuarioMenu().Cadastro(usuarioMenus);

                MensagemOK1.ShowMessage("Acesso Liberado com Sucesso.");
            }
            catch (Exception erro)
            {
                MensagemOK1.ShowMessage(erro.Message);
            }
        }

        protected void gdvAcesso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "&nbsp;")
                {

                }
                else
                    e.Row.Cells[1].Text = string.Format("<img src='{0}'/>", ResolveClientUrl("~/imagens/" + e.Row.Cells[1].Text));


                if (menus.Where(c => c.Id.Equals(e.Row.Cells[3].Text.ToInt())).FirstOrDefault() != null)
                {
                    CheckBox ch = (CheckBox)e.Row.FindControl("CbAcesso");
                    ch.Checked = true;
                }


            }
        }

        protected void gdvAcesso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAcesso.PageIndex = e.NewPageIndex;
            MontaMenu();
        }
    }
}