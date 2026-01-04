using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleFinanceiro.UI.Presentation.WebControl
{
    public partial class MensagemOK : System.Web.UI.UserControl
    {
        public void ShowMessage(string Texto)
        {
            ShowMessage("Aviso!!!", Texto);
        }

        public void ShowMessage(string Titulo, string Texto)
        {
            lblMensagem.Text = Texto;
            lblTitulo.Text = Titulo;
            pnlMensagem.Visible = true;
            Panel_MessageOk_ModalPopupExtender.Show();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            pnlMensagem.Visible = false;
            
        }
    }
}