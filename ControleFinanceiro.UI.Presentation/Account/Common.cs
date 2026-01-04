using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ControleFinanceiro.UI.Presentation.App_Code
{
    public class Common
    {
        public class Tree<T>
        {
            public List<T> DataSource { get; set; }

            public string Id { get; set; }
            public string Descricao { get; set; }
            public string IdPai { get; set; }

            protected void Page_Load(object sender, EventArgs e)
            {

            }

            public TreeNode DataBind()
            {
                return Traverse(DataSource);
            }

            TreeNode Traverse(List<T> carteiras)
            {
                return Traverse(carteiras[0], carteiras);
            }
            TreeNode Traverse(T carteira, List<T> Geral)
            {
                carteira.GetType().GetProperty(Descricao).GetValue(carteira, null);
                TreeNode menu = new TreeNode(carteira.GetType().GetProperty(Descricao).GetValue(carteira, null).ToString(), carteira.GetType().GetProperty(Id).GetValue(carteira, null).ToString());
                List<T> subCarteiras = RetornaSubList(Geral, IdPai, carteira.GetType().GetProperty(Id).GetValue(carteira, null).ToString());

                for (int i = 0; i < subCarteiras.Count; i++)
                {
                    menu.ChildNodes.Add(Traverse(subCarteiras[i], Geral));
                }

                return menu;
            }
            List<T> RetornaSubList(List<T> lista, string Campo, string Valor)
            {
                List<T> Sublista = new List<T>();

                foreach (T aux in lista)
                {
                    if (aux.GetType().GetProperty(Campo).GetValue(aux, null).ToString() == Valor)
                        Sublista.Add(aux);
                }

                return Sublista;
            }
        }

        public static string intToMes(int i)
        {
            string retorno = string.Empty;
            switch (i)
            {
                case 1: retorno = "Jan"; break;
                case 2: retorno = "Fev"; break;
                case 3: retorno = "Mar"; break;
                case 4: retorno = "Abr"; break;
                case 5: retorno = "Mai"; break;
                case 6: retorno = "Jun"; break;
                case 7: retorno = "Jul"; break;
                case 8: retorno = "Ago"; break;
                case 9: retorno = "Set"; break;
                case 10: retorno = "Out"; break;
                case 11: retorno = "Nov"; break;
                case 12: retorno = "Dez"; break;
            }

            return retorno;
        }
    }
    public static class Cs_Html
    {
        public static string AcertaHtmlAcentro(string Dado)
        {
            string Mensagem = "";
            Mensagem = Dado.ToString();
            Mensagem = Mensagem.Replace("&#161;", "¡");
            Mensagem = Mensagem.Replace("&#162;", "¢");
            Mensagem = Mensagem.Replace("&#163;", "£");
            Mensagem = Mensagem.Replace("&#164;", "¤");
            Mensagem = Mensagem.Replace("&#165;", "¥");
            Mensagem = Mensagem.Replace("&#166;", "¦");
            Mensagem = Mensagem.Replace("&#167;", "§");
            Mensagem = Mensagem.Replace("&#168;", "¨");
            Mensagem = Mensagem.Replace("&#169;", "©");
            Mensagem = Mensagem.Replace("&#170;", "ª");
            Mensagem = Mensagem.Replace("&#171;", "«");
            Mensagem = Mensagem.Replace("&#172;", "¬");
            Mensagem = Mensagem.Replace("&#173;", "�­");
            Mensagem = Mensagem.Replace("&#174;", "®");
            Mensagem = Mensagem.Replace("&#175;", "¯");
            Mensagem = Mensagem.Replace("&#176;", "°");
            Mensagem = Mensagem.Replace("&#177;", "±");
            Mensagem = Mensagem.Replace("&#178;", "²");
            Mensagem = Mensagem.Replace("&#179;", "³");
            Mensagem = Mensagem.Replace("&#180;", "´");
            Mensagem = Mensagem.Replace("&#181;", "µ");
            Mensagem = Mensagem.Replace("&#182;", "¶");
            Mensagem = Mensagem.Replace("&#183;", "·");
            Mensagem = Mensagem.Replace("&#184;", "¸");
            Mensagem = Mensagem.Replace("&#185;", "¹");
            Mensagem = Mensagem.Replace("&#186;", "º");
            Mensagem = Mensagem.Replace("&#187;", "»");
            Mensagem = Mensagem.Replace("&#188;", "¼");
            Mensagem = Mensagem.Replace("&#189;", "½");
            Mensagem = Mensagem.Replace("&#190;", "¾");
            Mensagem = Mensagem.Replace("&#191;", "¿");
            Mensagem = Mensagem.Replace("&#192;", "À");
            Mensagem = Mensagem.Replace("&#193;", "Á");
            Mensagem = Mensagem.Replace("&#194;", "Â");
            Mensagem = Mensagem.Replace("&#195;", "Ã");
            Mensagem = Mensagem.Replace("&#196;", "Ä");
            Mensagem = Mensagem.Replace("&#197;", "Å");
            Mensagem = Mensagem.Replace("&#198;", "Æ");
            Mensagem = Mensagem.Replace("&#199;", "Ç");
            Mensagem = Mensagem.Replace("&#200;", "È");
            Mensagem = Mensagem.Replace("&#201;", "É");
            Mensagem = Mensagem.Replace("&#202;", "Ê");
            Mensagem = Mensagem.Replace("&#203;", "Ë");
            Mensagem = Mensagem.Replace("&#204;", "Ì");
            Mensagem = Mensagem.Replace("&#205;", "Í");
            Mensagem = Mensagem.Replace("&#206;", "Î");
            Mensagem = Mensagem.Replace("&#207;", "Ï");
            Mensagem = Mensagem.Replace("&#208;", "Ð");
            Mensagem = Mensagem.Replace("&#209;", "Ñ");
            Mensagem = Mensagem.Replace("&#210;", "Ò");
            Mensagem = Mensagem.Replace("&#211;", "Ó");
            Mensagem = Mensagem.Replace("&#212;", "Ô");
            Mensagem = Mensagem.Replace("&#213;", "Õ");
            Mensagem = Mensagem.Replace("&#214;", "Ö");
            Mensagem = Mensagem.Replace("&#215;", "×");
            Mensagem = Mensagem.Replace("&#216;", "Ø");
            Mensagem = Mensagem.Replace("&#217;", "Ù");
            Mensagem = Mensagem.Replace("&#218;", "Ú");
            Mensagem = Mensagem.Replace("&#219;", "Û");
            Mensagem = Mensagem.Replace("&#220;", "Ü");
            Mensagem = Mensagem.Replace("&#221;", "Ý");
            Mensagem = Mensagem.Replace("&#222;", "Þ");
            Mensagem = Mensagem.Replace("&#223;", "ß");
            Mensagem = Mensagem.Replace("&#224;", "à");
            Mensagem = Mensagem.Replace("&#225;", "á");
            Mensagem = Mensagem.Replace("&#226;", "â");
            Mensagem = Mensagem.Replace("&#227;", "ã");
            Mensagem = Mensagem.Replace("&#228;", "ä");
            Mensagem = Mensagem.Replace("&#229;", "å");
            Mensagem = Mensagem.Replace("&#230;", "æ");
            Mensagem = Mensagem.Replace("&#231;", "ç");
            Mensagem = Mensagem.Replace("&#232;", "è");
            Mensagem = Mensagem.Replace("&#233;", "é");
            Mensagem = Mensagem.Replace("&#234;", "ê");
            Mensagem = Mensagem.Replace("&#235;", "ë");
            Mensagem = Mensagem.Replace("&#236;", "ì");
            Mensagem = Mensagem.Replace("&#237;", "í");
            Mensagem = Mensagem.Replace("&#238;", "î");
            Mensagem = Mensagem.Replace("&#239;", "ï");
            Mensagem = Mensagem.Replace("&#240;", "ð");
            Mensagem = Mensagem.Replace("&#241;", "ñ");
            Mensagem = Mensagem.Replace("&#242;", "ò");
            Mensagem = Mensagem.Replace("&#243;", "ó");
            Mensagem = Mensagem.Replace("&#244;", "ô");
            Mensagem = Mensagem.Replace("&#245;", "õ");
            Mensagem = Mensagem.Replace("&#246;", "ö");
            Mensagem = Mensagem.Replace("&#247;", "÷");
            Mensagem = Mensagem.Replace("&#248;", "ø");
            Mensagem = Mensagem.Replace("&#249;", "ù");
            Mensagem = Mensagem.Replace("&#250;", "ú");
            Mensagem = Mensagem.Replace("&#251;", "û");
            Mensagem = Mensagem.Replace("&#252;", "ü");
            Mensagem = Mensagem.Replace("&#253;", "ý");
            Mensagem = Mensagem.Replace("&#254;", "þ");
            Mensagem = Mensagem.Replace("&#255;", "ÿ");
            Mensagem = Mensagem.Replace("&#38;", "&");
            Mensagem = Mensagem.Replace("&#60;", "<");
            Mensagem = Mensagem.Replace("&#62;", ">");
            Mensagem = Mensagem.Replace("&#39;", "'");

            return Mensagem;
        }
    }


}