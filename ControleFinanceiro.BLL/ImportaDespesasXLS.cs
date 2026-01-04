using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ControleFinanceiro.BLL
{
    public class ImportaDespesasXLS
    {
        public void Importar(string CaminhoArquivo, DateTime Emissao, DateTime Vencimento, DateTime Pgto, int IdFornecedor, string descricao, int idUsuario, int idSegmento)
        {
            int IdDadosConta;
            List<DTO.ImportaDespesasXLS> importaDespesaXLS = new DAL.XLSX().RetornaEntidade<DTO.ImportaDespesasXLS>(CaminhoArquivo);

            //List<DTO.ControleAcessoUsuario> Grupos = new BLL.ControleAcessoUsuario().Select();
            List<DTO.HistoricoFuncionario> Grupos = new BLL.HistoricoFuncionario().SelectByDataCadastro(Emissao);

            string inconsistencia = GeraInconsistencia(importaDespesaXLS, Grupos);

            if ((inconsistencia != string.Empty))
            {
                throw new Exception(string.Format("Inconsistencia|{0}", inconsistencia));
            }
            else
            {
                List<DTO.DadosBancario> dadosBancarios = new BLL.DadosBancario().Select();

                var DadosBancarios = importaDespesaXLS.GroupBy(c => c.IdBanco);

                foreach (var dado in DadosBancarios)
                {
                    List<DTO.ImportaDespesasXLS> Groupxls = importaDespesaXLS.Where(c => c.IdBanco.Equals(dado.Key)).ToList();

                    foreach (var carteira in Grupos.GroupBy(c => c.IdCarteira))
                    {
                        decimal Valor = 0;

                        foreach (var usuario in carteira.ToList())
                        {
                            int Matricula = Convert.ToInt32(usuario.Matricula);
                            DTO.ImportaDespesasXLS despesa = Groupxls.Where(c => c.Matricula.Equals(Matricula)).FirstOrDefault();

                            if (despesa == null)
                                continue;

                            Valor += despesa.Valor;
                        }


                        #region despesa
                        {
                            string htmlCarteira = HTMLCarteira(carteira.OrderBy(c => c.Nome).ToList(), Groupxls, 0);

                            DTO.Despesa despesa = new DTO.Despesa();
                            despesa.Id = -1;
                            despesa.DataCadastro = DateTime.Now;
                            despesa.Descricao = descricao;
                            despesa.DtPgto = Pgto;
                            despesa.Vencimento = Vencimento;
                            despesa.Emissao = Emissao;
                            despesa.IdCarteira = carteira.ToList()[0].IdCarteira;
                            despesa.IdDadosBancario = dadosBancarios.Where(c=>c.Descricao.Equals(Groupxls[0].IdBanco)).FirstOrDefault().Id;
                            despesa.IdFornecedor = IdFornecedor;
                            despesa.IdUsuario = idUsuario;
                            despesa.IdSegmento = idSegmento;
                            despesa.Valor = Valor;
                            despesa.Nota = Encoding.ASCII.GetBytes(htmlCarteira);
                            despesa.ExtensaoNota = ".html";

                            new DAL.Despesa().Cadastro(despesa);
                        }
                        #endregion
                    }
                }
                
            }
        }

        private string HTMLCarteira(List<DTO.HistoricoFuncionario> Usuarios, List<DTO.ImportaDespesasXLS> cargosSalarios, int tipo)
        {
            #region Monta Grid demonstrativo
            string[,] Tabela = new string[Usuarios.Count, 3];
            for (int i = 0; i < Usuarios.Count; i++)
            {
                DTO.HistoricoFuncionario usuario = Usuarios[i];

                int Matricula = 0;
                string strSalario = string.Empty;

                if (!int.TryParse(usuario.Matricula, out Matricula))
                    strSalario = "#N/D";
                else
                {
                    DTO.ImportaDespesasXLS Salario = cargosSalarios.Where(c => c.Matricula.Equals(Matricula)).FirstOrDefault();
                    if (Salario == null)
                        strSalario = "#N/D";
                    else
                    {
                            strSalario = Salario.Valor.ToString("c");
                    }
                }

                Tabela[i, 0] = usuario.Matricula.ToString();
                Tabela[i, 1] = usuario.Nome;
                Tabela[i, 2] = strSalario;
            }
            #endregion

            return MontaHTML(Tabela);
        }

        private string GeraInconsistencia(List<DTO.ImportaDespesasXLS> cargosSalarios, List<DTO.HistoricoFuncionario> Grupos)
        {
            DateTime Agora = DateTime.Now;

            string Caminho = string.Format("{0}Inconsistencia\\{1}", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss"));

            if (!Directory.Exists(Caminho))
                Directory.CreateDirectory(Caminho);

            bool GeraArquivo = false;

            string Sistema = string.Empty, Planilha = string.Empty;
            #region Sistema
            {
                string[,] TabelaSistema = new string[Grupos.Count, 3];
                bool ContemFalha = false;
                for (int i = 0; i < Grupos.Count; i++)
                {
                    DTO.HistoricoFuncionario usuario = Grupos[i];

                    int Matricula = 0;
                    string Checado = string.Empty;

                    if (!int.TryParse(usuario.Matricula, out Matricula))
                    {
                        
                        Checado = "#N/D";
                        ContemFalha = true;
                    }
                    else
                    {
                        DTO.ImportaDespesasXLS Salario = cargosSalarios.Where(c => c.Matricula.Equals(Matricula)).FirstOrDefault();
                        if (Salario == null)
                        {
                            Checado = "#N/D";
                            ContemFalha = true;
                        }
                        else
                            Checado = "OK";
                    }

                    TabelaSistema[i, 0] = Convert.ToString(usuario.Matricula);
                    TabelaSistema[i, 1] = usuario.Nome;
                    TabelaSistema[i, 2] = Checado;
                }
                if (ContemFalha)
                {
                    Sistema = MontaHTML(TabelaSistema);
                    GeraArquivo = true;
                }
            }
            #endregion


            #region Planilha
            {
                string[,] TabelaSistema = new string[cargosSalarios.Count, 3];
                bool ContemFalha = false;
                for (int i = 0; i < cargosSalarios.Count; i++)
                {
                    DTO.ImportaDespesasXLS salario = cargosSalarios[i];

                    int Matricula = 0;
                    string Checado = string.Empty;

                    if (!int.TryParse(salario.Matricula.ToString(), out Matricula))
                    {
                        Checado = "#N/D";
                        ContemFalha = true;
                    }
                    else
                    {
                        var auxgrupos = Grupos.Where(c => c.Matricula.Equals(salario.Matricula.ToString()));

                        if (auxgrupos.Count() > 1)
                        {
                            Checado = "Matriculas Repetido";
                            ContemFalha = true;
                        }
                        else
                        {

                            DTO.HistoricoFuncionario usuario = auxgrupos.FirstOrDefault();
                            if (usuario == null)
                            {
                                Checado = "#N/D";
                                ContemFalha = true;
                            }
                            else
                                Checado = "OK";
                        }
                    }

                    TabelaSistema[i, 0] = salario.Matricula.ToString();
                    TabelaSistema[i, 1] = salario.Nome;
                    TabelaSistema[i, 2] = Checado;
                }
                if (ContemFalha)
                {
                    Planilha = MontaHTML(TabelaSistema);
                    GeraArquivo = true;
                }
            }
            #endregion


            if (GeraArquivo)
            {
                using (StreamWriter write = new StreamWriter(string.Format("{0}\\Inconsistencia.html", Caminho)))
                    write.Write(string.Format(@"<html>
    <head>
        <Title>
            Demonstrativo Automatico
        </Title>
    </head>
    <body>
        <h1>Sistema sem coincidência na Planilha</h1>
        {0}
        <h1>Planilha sem coincidência no Sistema</h1>
        {1}
    </body>
</html>", Sistema, Planilha));

                return string.Format("{0}\\Inconsistencia.html", Caminho);
            }

            return string.Empty;
        }

        private string MontaHTML(string[,] Tabela)
        {
            #region Monta Grid
            StringBuilder sbGrid = new StringBuilder();

            for (int Linha = 0; Linha < Tabela.Length / (Tabela.Rank + 1); Linha++)
            {
                sbGrid.AppendLine("            <tr>");
                for (int Coluna = 0; Coluna <= Tabela.Rank; Coluna++)
                {
                    sbGrid.AppendLine(string.Format(@"                <td>{0}</td>", Tabela[Linha, Coluna]));
                }
                sbGrid.AppendLine("            </tr>");
            }
            #endregion



            #region Monta HTML Completo
            StringBuilder sbHTML = new StringBuilder();
            sbHTML.Append(string.Format(@"
        <table>
            <tr>
                <td><b>Matricula</b></td>
                <td><b>Nome</b></td>
                <td style='text-align:right;'><b>Valor</b></td>
            </tr>
{0}
        </table>
", sbGrid.ToString()));
            #endregion

            return sbHTML.ToString();
        }
    }


}
