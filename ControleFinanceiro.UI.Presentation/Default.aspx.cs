using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;


namespace ControleFinanceiro.UI.Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Teste();
                if (Session["Usuario"] != null)
                    Response.Redirect("~/Pages/Logados/Default.aspx", false);
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Usuario dtoLogin = new BLL.Usuario().Logar(tbUsuario.Text, tbSenha.Text);

                Session.Add("Usuario", dtoLogin);
                Response.Redirect("~/Pages/Logados/Default.aspx", false);

            }
            catch (Exception erro)
            {
                Alerta(erro.Message);
            }
        }

        public void Alerta(String mensagem)
        {
            string strScript = "<script> alert('" + mensagem + "')</script>";

            if (ExisteScriptManager())
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), mensagem, strScript, false);
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(String), mensagem, strScript, false);
            }
        }

        public Boolean ExisteScriptManager()
        {
            return (ScriptManager.GetCurrent(this) != null);
        }

        protected void Teste()
        {
            DTO.Usuario dtoUsuario = new DTO.Usuario();
            dtoUsuario.Id = 1;
            dtoUsuario.Nome = "Ali";
            dtoUsuario.Ativo = true;
            Session.Add("Usuario", dtoUsuario);
            Response.Redirect("~/Pages/Logados/Orcamento/Orcamento.aspx?IdSegmento=121");
        }
    }
}