using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class ImportarXlS : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.NomeAplicacao = "Importação Automatica de Despesa";
                Master.DescricaoAplicacao = "Tela para Inserir/Atualizar despesas de forma automatica atraves de planilha XLS.";

                TreeViewSegmento();

                lstFornecedor.DataSource = new BLL.Fornecedor().Select().OrderBy(c => c.Nome).ToList();
                lstFornecedor.DataTextField = "Nome";
                lstFornecedor.DataValueField = "Id";
                lstFornecedor.DataBind();
            }
        }

        private void TreeViewSegmento()
        {
            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
            tree.DataSource = new BLL.Segmento().Select().Where(c => c.IdTipoSegmento.Equals(2)).ToList();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwSegmento.Nodes.Clear();
            trwSegmento.Nodes.Add(tree.DataBind());
            trwSegmento.DataBind();
        }

        protected void trwSegmento_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (new BLL.Segmento().SelectPeloIdPai(trwSegmento.SelectedValue.ToInt()).Count == 0)
            {
                hdfIdSegmento.Value = trwSegmento.SelectedValue;
            }
        }
        protected void BtnCadastroSalvar_Click(object sender, EventArgs e)
        {
            if ((hdfIdSegmento.Value != "-1"))
            {
                string descricao = txtDescricao.Text;
                DateTime Emissao;
                DateTime Vencimento;
                DateTime Pgto;
                int IdDadosConta;
                int IdFornecedor;
                int idSegmento;

                if (!DateTime.TryParse(txtEmissao.Text, out Emissao))
                    return;
                if (!DateTime.TryParse(txtVencimento.Text, out Vencimento))
                    return;
                if (!DateTime.TryParse(txtDtPgto.Text, out Pgto))
                    return;

                if (lstFornecedor.SelectedIndex != -1)
                    IdFornecedor = lstFornecedor.SelectedValue.ToInt();
                else
                    return;

                idSegmento = hdfIdSegmento.Value.ToInt();

                if (!Directory.Exists(@"c:\Financeiro"))
                    Directory.CreateDirectory(@"c:\Financeiro");

                FileUpload1.SaveAs(string.Format(@"c:\Financeiro\{0}", FileUpload1.FileName));


                string CaminhoArquivo = string.Format(@"c:\Financeiro\{0}", FileUpload1.FileName);

                try
                {
                    new BLL.ImportaDespesasXLS().Importar(CaminhoArquivo, Emissao, Vencimento, Pgto, IdFornecedor, descricao, ((DTO.Usuario)Session["Usuario"]).Id, idSegmento);
                    Master.ShowMessage("Arquivo Processado com Sucesso!!!");
                }
                catch (Exception Erro)
                {
                    if (Erro.Message.Contains("Inconsistencia"))
                    {
                        DateTime Agora = DateTime.Now;

                        using (FileStream fs = File.OpenRead(Erro.Message.Split('|')[1]))
                        {
                            int length = (int)fs.Length;
                            byte[] buffer;

                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                buffer = br.ReadBytes(length);
                            }

                            Response.Clear();
                            Response.Buffer = true;
                            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", Path.GetFileName(string.Format("{0}\\Inconsistencia\\{1}.html", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss")))));
                            Response.ContentType = "application/" + Path.GetExtension(string.Format("{0}\\Inconsistencia\\{1}.html", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss"))).Substring(1);
                            Response.BinaryWrite(buffer);
                        }
                    }
                }
            }


        }

        protected void btnManutencao_Click(object sender, EventArgs e)
        {
            string script = string.Format("abrir_popup('HistoricoFuncionario.aspx?DataEmissao={0}','Funcionarios',800,600)", txtEmissao.Text);

             ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}