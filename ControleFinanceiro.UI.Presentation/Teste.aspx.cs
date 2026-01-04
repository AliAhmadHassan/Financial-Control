using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace ControleFinanceiro.UI.Presentation
{
    public partial class Teste : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //new BLL.RHCargosSalarios().Importar(@"Z:\CARGOS E SALÁRIO.xlsx");
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