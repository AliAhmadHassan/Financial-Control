using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos
{
    public partial class ExportaListaFuncionarios : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.NomeAplicacao = "Lista Funcionarios";
            Master.DescricaoAplicacao = "Tela para gerar lista de funcionarios que será utilizado para importação de despesas.";
        }

        protected void btnGeraListaFunc_Click(object sender, EventArgs e)
        {
            string Caminho = new BLL.ExportaListaFuncionarios().Exportar();

            using (FileStream fs = File.OpenRead(Caminho))
            {
                int length = (int)fs.Length;
                byte[] buffer;

                using (BinaryReader br = new BinaryReader(fs))
                {
                    buffer = br.ReadBytes(length);
                }

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", Caminho));
                Response.ContentType = "application/" + Path.GetExtension(string.Format("{0}", Caminho)).Substring(1);
                Response.BinaryWrite(buffer);
            }
        }
    }
}