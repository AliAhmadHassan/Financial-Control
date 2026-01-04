using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos
{
    public partial class ImportarSalarios : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.NomeAplicacao = "Importação de Arquivo Salario";
                Master.DescricaoAplicacao = "Tela para Inserir/Atualizar os Salarios dos funcionarios e lançamento de custo.";

                lstDadosBancario.DataSource = new BLL.DadosBancario().Select().OrderBy(c => c.Descricao).ToList();
                lstDadosBancario.DataTextField = "Descricao";
                lstDadosBancario.DataValueField = "Id";
                lstDadosBancario.DataBind();

                lstFornecedor.DataSource = new BLL.Fornecedor().Select().OrderBy(c => c.Nome).ToList();
                lstFornecedor.DataTextField = "Nome";
                lstFornecedor.DataValueField = "Id";
                lstFornecedor.DataBind();
            }
        }

        protected void BtnCadastroSalvar_Click(object sender, EventArgs e)
        {

            string descricao = txtDescricao.Text;
            DateTime Emissao;
            DateTime Vencimento;
            DateTime Pgto;
            int IdDadosConta;
            int IdFornecedor;

            if (!DateTime.TryParse(txtEmissao.Text, out Emissao))
                return;
            if (!DateTime.TryParse(txtVencimento.Text, out Vencimento))
                return;
            if (!DateTime.TryParse(txtDtPgto.Text, out Pgto))
                return;

            if (lstDadosBancario.SelectedIndex != -1)
                IdDadosConta = lstDadosBancario.SelectedValue.ToInt();
            else
                return;

            if (lstFornecedor.SelectedIndex != -1)
                IdFornecedor = lstFornecedor.SelectedValue.ToInt();
            else
                return;


            if (!Directory.Exists(@"c:\Financeiro"))
                Directory.CreateDirectory(@"c:\Financeiro");

            FileUpload1.SaveAs(string.Format(@"c:\Financeiro\{0}", FileUpload1.FileName));


            string CaminhoArquivo = string.Format(@"c:\Financeiro\{0}", FileUpload1.FileName);

            try
            {
                new BLL.RHCargosSalarios().Importar(CaminhoArquivo, Emissao, Vencimento, Pgto, IdDadosConta, IdFornecedor, descricao, ((DTO.Usuario)Session["Usuario"]).Id);
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
                        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", Path.GetFileName(string.Format("{0}\\Inconsistencia\\{1}.zip", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss")))));
                        Response.ContentType = "application/" + Path.GetExtension(string.Format("{0}\\Inconsistencia\\{1}.zip", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss"))).Substring(1);
                        Response.BinaryWrite(buffer);
                    }
                }
            }

            
        }
    }
}