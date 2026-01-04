using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Telefonia
{
    public partial class STIRamal : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTela();
            }
        }

        protected void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro STI-Ramais";
            Master.DescricaoAplicacao = "Tela para Cadastro De Ramais para Sistema STI.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {

        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            if (hdfIdCarteira.Value == "")
            {
                Master.ShowMessage("Favor Selecionar uma Carteira!");
            }
            else
            if (hdfIdCadastro.Value.ToInt() == -1)
            {
                DTO.STIRamal stiRamal = new DTO.STIRamal();
                stiRamal.Central = txtCentral.Text.ToInt();
                stiRamal.IdCarteira = hdfIdCarteira.Value.ToInt();
                stiRamal.Ramal = txtRamal.Text.ToInt();
                stiRamal.Andar = txtAndar.Text;
                stiRamal.Sala = txtSala.Text;

                new BLL.STIRamal().Cadastro(stiRamal);
                Master.ShowMessage("STI\\Ramal Cadastrado com Sucesso!");
                MontaGrid();
            }
            else
            {
                DTO.STIRamal stiRamal = new BLL.STIRamal().SelectPelaPK(hdfIdCadastro.Value.ToInt());
                stiRamal.Central = txtCentral.Text.ToInt();
                stiRamal.Ramal = txtRamal.Text.ToInt();
                stiRamal.Andar = txtAndar.Text;
                stiRamal.Sala = txtSala.Text;

                new BLL.STIRamal().Cadastro(stiRamal);
                Master.ShowMessage("STI\\Ramal Cadastrado com Sucesso!");
                MontaGrid();
            }
        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            hdfIdCarteira.Value = trwCarteira.SelectedValue.ToString();
            MontaGrid();
        }

        private void MontaGrid()
        {
            GdvSTIRamal.DataSource = new BLL.STIRamal().SelectPelaCarteira(hdfIdCarteira.Value.ToInt());
            GdvSTIRamal.DataBind();
        }

        

        protected void GdvSTIRamal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvSTIRamal.PageIndex = e.NewPageIndex;
            MontaGrid();
        }

        protected void GdvSTIRamal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvSTIRamal.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvSTIRamal.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void Excluir(int p)
        {
            DTO.STIRamal stiRamal = new BLL.STIRamal().SelectPelaPK(p);
            new BLL.STIRamal().Remover(stiRamal);
            Master.ShowMessage("Removido com Sucesso!");
            MontaGrid();
        }

        private void PopularCampos(int p)
        {
            DTO.STIRamal stiRamal = new BLL.STIRamal().SelectPelaPK(p);
            txtCentral.Text = stiRamal.Central.ToString();
            txtRamal.Text = stiRamal.Ramal.ToString();
            txtAndar.Text = stiRamal.Andar;
            txtSala.Text = stiRamal.Sala;
            hdfIdCadastro.Value = p.ToString();

            Panel_Cadastro_ModalPopupExtender.Show();
        }

        protected void GdvSTIRamal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[4].Text = new BLL.Carteira().SelectPelaPK(e.Row.Cells[4].Text.ToInt()).Descricao;
        }

    }
}