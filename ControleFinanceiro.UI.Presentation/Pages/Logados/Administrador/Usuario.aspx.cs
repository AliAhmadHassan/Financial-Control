using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class Usuario : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTela();
            }
        }

        private void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro Usuario";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção de Usuarios.";

            GdvUsuario.DataSource = new BLL.Usuario().Select();
            GdvUsuario.DataBind();

            lstPerfil.DataSource = new BLL.Perfil().Select();
            lstPerfil.DataValueField = "Id";
            lstPerfil.DataTextField = "Descricao";
            lstPerfil.DataBind();

            IdCadastrar.Value = "-1";
        }

        protected void GdvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = new BLL.Perfil().SelectPelaPK(e.Row.Cells[4].Text.ToInt()).Descricao;
            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            IdCadastrar.Value = "-1";
            txtNome.Text = string.Empty;
            cbxAtivo.Checked = true;

        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Usuario usuario = new DTO.Usuario();
                usuario.Id = IdCadastrar.Value.ToInt();
                usuario.Ativo = cbxAtivo.Checked;
                usuario.Nome = txtNome.Text;
                usuario.IdPerfil = lstPerfil.SelectedValue.ToInt();
                new BLL.Usuario().Cadastro(usuario);
                Master.ShowMessage("Cadastrado com Sucesso!");
                MontaTela();
            }
            catch (Exception erro)
            {
                Master.ShowMessage(erro.Message);
            }

        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void GdvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvUsuario.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvUsuario.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text.Replace("&nbsp;", string.Empty)));
                    break;
                case "Acesso":
                    string script = string.Format("abrir_popup('DefineAcesso.aspx?Usuario={0}','Receita',800,600)", GdvUsuario.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
                    break;

            }
        }

        private void Excluir(int id)
        {
            DTO.Usuario usuario = new BLL.Usuario().SelectPelaPK(id);
            usuario.Ativo = false;
            new BLL.Usuario().Cadastro(usuario);
        }

        private void PopularCampos(int id)
        {
            DTO.Usuario usuario = new BLL.Usuario().SelectPelaPK(id);
            txtNome.Text = usuario.Nome;
            IdCadastrar.Value = usuario.Id.ToString();
            lstPerfil.SelectedValue = usuario.IdPerfil.ToString();
            cbxAtivo.Checked = usuario.Ativo;
            Panel_Cadastrar_ModalPopupExtender.Show();
        }

        protected void GdvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvUsuario.PageIndex = e.NewPageIndex;
            MontaTela();
        }
    }
}