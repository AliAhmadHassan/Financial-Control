using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;
using System.Text;
using System.IO;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.ParqueGrafico
{
    public partial class Boleto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.NomeAplicacao = "Cadastro Boletos";
                Master.DescricaoAplicacao = "Modulo para Importação de Boletos por Carteira";
                ddlMes.Items.Clear();
                for (int i = 0; i < 6; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = MesReferente(DateTime.Today.AddMonths(-i).Month) + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");
                    item.Value = DateTime.Today.AddMonths(-i).Month.ToString("00") + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");

                    ddlMes.Items.Add(item);


                }
                MontaGrid(ddlMes.SelectedValue);
            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            lstCarteira.Items.Clear();
            lstCarteira.DataSource = new BLL.Carteira().Select();
            lstCarteira.DataTextField = "Descricao";
            lstCarteira.DataValueField = "Id";
            lstCarteira.DataBind();
            IdCadastrar.Value = "-1";
        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            StringBuilder SbRetorno = new BLL.CobNetBoletos().ProcessaBoleto(txtFacDe.Text.ToDateTime(), txtFacAte.Text.ToDateTime(), txtFranquiaDe.Text.ToDateTime(), txtFranquiaAte.Text.ToDateTime(), ddlMes.SelectedValue.Split('/')[0].ToInt(), ddlMes.SelectedValue.Split('/')[1].ToInt());

            if (!string.IsNullOrEmpty(SbRetorno.ToString()))
            {
                using (StreamWriter Write = new StreamWriter(string.Format(@"C:\ControleFinanceiro\Log{0}.txt", DateTime.Today.ToString("yyyyMMdd"))))
                    Write.Write(SbRetorno.ToString());

                Master.ShowMessage(SbRetorno.ToString());
            }
        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MontaGrid(ddlMes.SelectedValue);
        }

        private void MontaGrid(string Referencia)
        {
            GdvBoleto.DataSource = new BLL.Boleto().SelectPelaReferencia(Referencia.Split('/')[0].ToInt(), Referencia.Split('/')[1].ToInt());
            GdvBoleto.DataBind();
        }

        protected void GdvBoleto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = new BLL.Carteira().SelectPelaPK(e.Row.Cells[2].Text.ToInt()).Descricao;
                e.Row.Cells[4].Text = new BLL.Usuario().SelectPelaPK(e.Row.Cells[4].Text.ToInt()).Nome;
                e.Row.Cells[5].Text = e.Row.Cells[5].Text == "1" ? "FAC" : "Franquia";
            }
        }

        protected void GdvBoleto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvBoleto.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvBoleto.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void Excluir(int p)
        {
            DTO.Boleto boleto = new BLL.Boleto().SelectPelaPK(p);
            new BLL.Boleto().Remover(boleto);
            Master.ShowMessage("Removido com Sucesso!");
            MontaGrid(ddlMes.SelectedValue);
        }

        private void PopularCampos(int p)
        {
            lstCarteira.Items.Clear();
            lstCarteira.DataSource = new BLL.Carteira().Select();
            lstCarteira.DataTextField = "Descricao";
            lstCarteira.DataValueField = "Id";
            lstCarteira.DataBind();


            DTO.Boleto boleto = new BLL.Boleto().SelectPelaPK(p);
            txtQuantidade.Text = boleto.Quantidade.ToString();
            lstCarteira.Items.FindByValue(boleto.IdCarteira.ToString()).Selected = true;
            IdCadastrar.Value = p.ToString();

            Panel_Cadastro_ModalPopupExtender.Show();
        }

        protected void GdvBoleto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvBoleto.PageIndex = e.NewPageIndex;
            MontaGrid(ddlMes.SelectedValue);
        }

        protected void BtnImportar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCadastroSim_Click(object sender, EventArgs e)
        {
            if (lstCarteira.SelectedIndex == -1)
            {
                Master.ShowMessage("Favor Selecionar uma Carteira!");
            }
            else
                if (IdCadastrar.Value.ToInt() == -1)
                {
                    DTO.Boleto boleto = new DTO.Boleto();
                    boleto.Data = DateTime.Now;
                    boleto.IdCarteira = lstCarteira.SelectedValue.ToInt();
                    boleto.Mes = ddlMes.SelectedValue.Split('/')[0].ToInt();
                    boleto.Ano = ddlMes.SelectedValue.Split('/')[1].ToInt();
                    boleto.IdUsuario = 1;
                    boleto.Quantidade = txtQuantidade.Text.ToInt();
                    boleto.IdCarteira = lstCarteira.SelectedValue.ToInt();
                    new BLL.Boleto().Cadastro(boleto);
                    Master.ShowMessage("Boleto Cadastrado com Sucesso!");
                    MontaGrid(ddlMes.SelectedValue);
                }
                else
                {
                    DTO.Boleto boleto = new BLL.Boleto().SelectPelaPK(IdCadastrar.Value.ToInt());
                    boleto.Quantidade = txtQuantidade.Text.ToInt();
                    boleto.IdCarteira = lstCarteira.SelectedValue.ToInt();
                    new BLL.Boleto().Cadastro(boleto);
                    Master.ShowMessage("Boleto Alterado com Sucesso!");
                    MontaGrid(ddlMes.SelectedValue);
                }
        }
    }
}