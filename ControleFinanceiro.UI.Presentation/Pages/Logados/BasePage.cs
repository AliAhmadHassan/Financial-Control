using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Web.UI.HtmlControls;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados
{
    public class BasePage : Page
    {
        public BasePage()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("~/Default.aspx");

            if (Request.Url.AbsolutePath != "/Pages/Logados/Default.aspx")
            {
                List<DTO.Menu> menus = new BLL.Menu().SelectPelaIdUsuario(((DTO.Usuario)Session["Usuario"]).Id);
                if (menus.Where(c => c.URL.Equals(Request.Url.AbsolutePath.Replace("/Pages/Logados/", ""))).FirstOrDefault() == null)
                    Response.Redirect("~/Pages/Logados/Default.aspx");
            }

            base.OnLoad(e);

            var header = (HtmlHead)Page.Header;

            ClientScript.RegisterClientScriptInclude(Guid.NewGuid().ToString(), Page.ResolveClientUrl("~/Scripts/jquery-1.9.1.js"));
            ClientScript.RegisterClientScriptInclude(Guid.NewGuid().ToString(), Page.ResolveClientUrl("~/Scripts/jvalidacao.js"));
            ClientScript.RegisterClientScriptInclude(Guid.NewGuid().ToString(), Page.ResolveClientUrl("~/Scripts/Common.js"));
        }

        public void Confirm(String mensagem)
        {
            string strScript = "<script> return confirm('" + mensagem + "')</script>";

            ClientScript.RegisterStartupScript(typeof(String), mensagem, strScript, false);

        }

        public Boolean ExisteScriptManager()
        {
            return (ScriptManager.GetCurrent(this) != null);
        }

        //public static void logOut()
        //{
        //    FormsAuthentication.SignOut();

        //}

        public void ExecutarScript(String script)
        {
            string strScript = "<script>" + script + "</script>";
            if (ExisteScriptManager())
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), script, strScript, false);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof(String), script, strScript, false);
            }
        }

        public static string MesReferente(int intMes)
        {
            string sMes = string.Empty;
            if (intMes == 1)
                sMes = "Janeiro";
            if (intMes == 2)
                sMes = "Fevereiro";
            if (intMes == 3)
                sMes = "Março";
            if (intMes == 4)
                sMes = "Abril";
            if (intMes == 5)
                sMes = "Maio";
            if (intMes == 6)
                sMes = "Junho";
            if (intMes == 7)
                sMes = "Julho";
            if (intMes == 8)
                sMes = "Agosto";
            if (intMes == 9)
                sMes = "Setembro";
            if (intMes == 10)
                sMes = "Outubro";
            if (intMes == 11)
                sMes = "Novembro";
            if (intMes == 12)
                sMes = "Dezembro";

            return sMes;
        }

        public static string disparaEmail(string assunto, string enderecoEmail, string mensagem)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient Smtp = new SmtpClient();

                NetworkCredential Cr = new NetworkCredential();
                string Host, Usuario, Senha, Port;
                //Port = "587";
                //Usuario = "cargaitauauto@uol.com.br";
                //Senha = "mfdy15";
                //Host = "smtps.uol.com.br";
                Port = "25";
                Usuario = "cobnet@orcozol.com.br";
                Senha = "cobn123";
                Host = "smtp.orcozol.com.br";

                Cr.UserName = Usuario;
                Cr.Password = Senha;

                Smtp.Credentials = Cr;


                //****************************************************************************************************
                // Enviando E-Mail
                //****************************************************************************************************
                email.From = new MailAddress(Usuario);
                email.Subject = assunto;
                email.To.Add(enderecoEmail);
                email.IsBodyHtml = false;

                // texto do email
                email.Body = mensagem;

                Smtp.Host = Host;
                Smtp.Port = Convert.ToInt32(Port);

                Smtp.Send(email);
                return "Envio de email com sucesso!";
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static string ConvertNumAlfa(int Num)
        {
            string[] Matrix = new string[79];
            Matrix[1] = "A";
            Matrix[2] = "B";
            Matrix[3] = "C";
            Matrix[4] = "D";
            Matrix[5] = "E";
            Matrix[6] = "F";
            Matrix[7] = "G";
            Matrix[8] = "H";
            Matrix[9] = "I";
            Matrix[10] = "J";
            Matrix[11] = "K";
            Matrix[12] = "L";
            Matrix[13] = "M";
            Matrix[14] = "N";
            Matrix[15] = "O";
            Matrix[16] = "P";
            Matrix[17] = "Q";
            Matrix[18] = "R";
            Matrix[19] = "S";
            Matrix[20] = "T";
            Matrix[21] = "U";
            Matrix[22] = "V";
            Matrix[23] = "W";
            Matrix[24] = "X";
            Matrix[25] = "Y";
            Matrix[26] = "Z";
            Matrix[27] = "AA";
            Matrix[28] = "AB";
            Matrix[29] = "AC";
            Matrix[30] = "AD";
            Matrix[31] = "AE";
            Matrix[32] = "AF";
            Matrix[33] = "AG";
            Matrix[34] = "AH";
            Matrix[35] = "AI";
            Matrix[36] = "AJ";
            Matrix[37] = "AK";
            Matrix[38] = "AL";
            Matrix[39] = "AM";
            Matrix[40] = "AN";
            Matrix[41] = "AO";
            Matrix[42] = "AP";
            Matrix[43] = "AQ";
            Matrix[44] = "AR";
            Matrix[45] = "AS";
            Matrix[46] = "AT";
            Matrix[47] = "AU";
            Matrix[48] = "AV";
            Matrix[49] = "AW";
            Matrix[50] = "AX";
            Matrix[51] = "AY";
            Matrix[52] = "AZ";
            Matrix[53] = "BA";
            Matrix[54] = "BB";
            Matrix[55] = "BC";
            Matrix[56] = "BD";
            Matrix[57] = "BE";
            Matrix[58] = "BF";
            Matrix[59] = "BG";
            Matrix[60] = "BH";
            Matrix[61] = "BI";
            Matrix[62] = "BJ";
            Matrix[63] = "BK";
            Matrix[64] = "BL";
            Matrix[65] = "BM";
            Matrix[66] = "BN";
            Matrix[67] = "BO";
            Matrix[68] = "BP";
            Matrix[69] = "BQ";
            Matrix[70] = "BR";
            Matrix[71] = "BS";
            Matrix[72] = "BT";
            Matrix[73] = "BU";
            Matrix[74] = "BV";
            Matrix[75] = "BW";
            Matrix[76] = "BX";
            Matrix[77] = "BY";
            Matrix[78] = "BZ";
            return Matrix[Num + 1];
        }
    }
}