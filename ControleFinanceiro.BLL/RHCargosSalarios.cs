using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ControleFinanceiro.BLL
{
    public class RHCargosSalarios
    {
        public void Importar(string CaminhoArquivo, DateTime Emissao, DateTime Vencimento, DateTime Pgto, int IdDadosConta, int IdFornecedor, string descricao, int idUsuario)
        {
            List<DTO.CargosSalariosExtraordinario> cargosSalarios = new DAL.XLSX().RetornaEntidade<DTO.CargosSalariosExtraordinario>(CaminhoArquivo);

            List<DTO.ControleAcessoUsuario> Grupos = new BLL.ControleAcessoUsuario().Select();

            string inconsistencia = GeraInconsistencia(cargosSalarios, Grupos);

            if ((inconsistencia != string.Empty))
            {
                throw new Exception(string.Format("Inconsistencia|{0}", inconsistencia));
            }
            else
            {
                AlteraSalarios(cargosSalarios, Grupos);

                foreach (var carteira in Grupos.GroupBy(c => c.IdCarteira))
                {
                    decimal Valor = 0, ValorVR = 0, ValorTrans = 0;
                    foreach (var usuario in carteira.ToList())
                    {
                        int Matricula = Convert.ToInt32(usuario.Matricula);
                        DTO.CargosSalariosExtraordinario Salario = cargosSalarios.Where(c => c.RE.Equals(Matricula)).FirstOrDefault();

                        if (Salario == null)
                            continue;

                        Valor += Salario.TotalVencimento;
                        ValorVR += Salario.VR;
                        ValorTrans += Salario.VtPago;
                    }


                    #region Salario
                    {
                        string htmlCarteira = HTMLCarteira(carteira.OrderBy(c => c.Nome).ToList(), cargosSalarios, 0);

                        DTO.Despesa despesa = new DTO.Despesa();
                        despesa.Id = -1;
                        despesa.DataCadastro = DateTime.Now;
                        despesa.Descricao = descricao;
                        despesa.DtPgto = Pgto;
                        despesa.Vencimento = Vencimento;
                        despesa.Emissao = Emissao;
                        despesa.IdCarteira = carteira.ToList()[0].IdCarteira;
                        despesa.IdDadosBancario = IdDadosConta;
                        despesa.IdFornecedor = IdFornecedor;
                        despesa.IdUsuario = idUsuario;
                        despesa.IdSegmento = 18;
                        despesa.Valor = Valor;
                        despesa.Nota = Encoding.ASCII.GetBytes(htmlCarteira);
                        despesa.ExtensaoNota = ".html";

                        new DAL.Despesa().Cadastro(despesa);
                    }
                    #endregion

                    #region VR
                    {
                        string htmlCarteira = HTMLCarteira(carteira.OrderBy(c => c.Nome).ToList(), cargosSalarios, 1);

                        DTO.Despesa despesa = new DTO.Despesa();
                        despesa.Id = -1;
                        despesa.DataCadastro = DateTime.Now;
                        despesa.Descricao = descricao;
                        despesa.DtPgto = Pgto;
                        despesa.Vencimento = Vencimento;
                        despesa.Emissao = Emissao;
                        despesa.IdCarteira = carteira.ToList()[0].IdCarteira;
                        despesa.IdDadosBancario = IdDadosConta;
                        despesa.IdFornecedor = IdFornecedor;
                        despesa.IdUsuario = idUsuario;
                        despesa.IdSegmento = 45;
                        despesa.Valor = ValorVR;
                        despesa.Nota = Encoding.ASCII.GetBytes(htmlCarteira);
                        despesa.ExtensaoNota = ".html";

                        new DAL.Despesa().Cadastro(despesa);
                    }
                    #endregion

                    #region VT
                    {
                        string htmlCarteira = HTMLCarteira(carteira.OrderBy(c => c.Nome).ToList(), cargosSalarios, 2);

                        DTO.Despesa despesa = new DTO.Despesa();
                        despesa.Id = -1;
                        despesa.DataCadastro = DateTime.Now;
                        despesa.Descricao = descricao;
                        despesa.DtPgto = Pgto;
                        despesa.Vencimento = Vencimento;
                        despesa.Emissao = Emissao;
                        despesa.IdCarteira = carteira.ToList()[0].IdCarteira;
                        despesa.IdDadosBancario = IdDadosConta;
                        despesa.IdFornecedor = IdFornecedor;
                        despesa.IdUsuario = idUsuario;
                        despesa.IdSegmento = 46;
                        despesa.Valor = ValorTrans;
                        despesa.Nota = Encoding.ASCII.GetBytes(htmlCarteira);
                        despesa.ExtensaoNota = ".html";

                        new DAL.Despesa().Cadastro(despesa);
                    }
                    #endregion
                }
            }
        }

        private void AlteraSalarios(List<DTO.CargosSalariosExtraordinario> cargosSalarios, List<DTO.ControleAcessoUsuario> Grupos)
        {
            foreach (DTO.CargosSalariosExtraordinario salario in cargosSalarios)
            {
                DTO.ControleAcessoUsuario usuario = Grupos.Where(c => c.Matricula.Equals(salario.RE.ToString())).FirstOrDefault();

                if (usuario == null)
                    continue;

                DTO.FuncionarioDespesas funcionarioDespesas = new DAL.FuncionarioDespesas().SelectPelaIdControleAcesso(usuario.Id);
                funcionarioDespesas.IdControleAcesso = usuario.Id;
                funcionarioDespesas.Salario = salario.SalarioBase;
                funcionarioDespesas.Extra = salario.Extraordinario;

                new DAL.FuncionarioDespesas().Cadastro(funcionarioDespesas);
            }
        }

        private string HTMLCarteira(List<DTO.ControleAcessoUsuario> Usuarios, List<DTO.CargosSalariosExtraordinario> cargosSalarios, int tipo)
        {
            #region Monta Grid demonstrativo
            string[,] Tabela = new string[Usuarios.Count, 3];
            for (int i = 0; i < Usuarios.Count; i++)
            {
                DTO.ControleAcessoUsuario usuario = Usuarios[i];

                int Matricula = 0;
                string strSalario = string.Empty;

                if (!int.TryParse(usuario.Matricula, out Matricula))
                    strSalario = "#N/D";
                else
                {
                    DTO.CargosSalariosExtraordinario Salario = cargosSalarios.Where(c => c.RE.Equals(Matricula)).FirstOrDefault();
                    if (Salario == null)
                        strSalario = "#N/D";
                    else
                    {
                        if (tipo == 0)
                            strSalario = Salario.TotalVencimento.ToString("c");
                        else if (tipo == 1)
                            strSalario = Salario.VR.ToString("c");
                        else
                            strSalario = Salario.VtPago.ToString("c");
                    }
                }

                Tabela[i, 0] = usuario.Matricula.ToString();
                Tabela[i, 1] = usuario.Nome;
                Tabela[i, 2] = strSalario;
            }
            #endregion

            return MontaHTML(Tabela);
        }

        private string GeraInconsistencia(List<DTO.CargosSalariosExtraordinario> cargosSalarios, List<DTO.ControleAcessoUsuario> Grupos)
        {
            DateTime Agora = DateTime.Now;

            string Caminho = string.Format("{0}Inconsistencia\\{1}", AppDomain.CurrentDomain.BaseDirectory, Agora.ToString("yyyyMMdd_HHmmss"));

            if (!Directory.Exists(Caminho))
                Directory.CreateDirectory(Caminho);

            bool GeraArquivo = false;
            #region Sistema
            {
                string[,] TabelaSistema = new string[Grupos.Count, 3];
                bool ContemFalha = false;
                for (int i = 0; i < Grupos.Count; i++)
                {
                    DTO.ControleAcessoUsuario usuario = Grupos[i];

                    int Matricula = 0;
                    string Checado = string.Empty;

                    if (!int.TryParse(usuario.Matricula, out Matricula))
                    {
                        Checado = "#N/D";
                        ContemFalha = true;
                    }
                    else
                    {
                        DTO.CargosSalariosExtraordinario Salario = cargosSalarios.Where(c => c.RE.Equals(Matricula)).FirstOrDefault();
                        if (Salario == null)
                        {
                            Checado = "#N/D";
                            ContemFalha = true;
                        }
                        else
                            Checado = "OK";
                    }

                    TabelaSistema[i, 0] = usuario.Matricula.ToString();
                    TabelaSistema[i, 1] = usuario.Nome;
                    TabelaSistema[i, 2] = Checado;
                }
                if (ContemFalha)
                {
                    using (StreamWriter write = new StreamWriter(string.Format("{0}\\Sistema.html", Caminho)))
                        write.Write(MontaHTML(TabelaSistema));
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
                    DTO.CargosSalariosExtraordinario salario = cargosSalarios[i];

                    int Matricula = 0;
                    string Checado = string.Empty;

                    if ((salario.RE == 1853) || (salario.RE == 1891) || (salario.RE == 2630) || (salario.RE == 2772))
                        ContemFalha = false;

                    if (!int.TryParse(salario.RE.ToString(), out Matricula))
                    {
                        Checado = "#N/D";
                        ContemFalha = true;
                    }
                    else
                    {
                        DTO.ControleAcessoUsuario usuario = Grupos.Where(c => c.Matricula.Equals(salario.RE.ToString())).FirstOrDefault();
                        if (usuario == null)
                        {
                            Checado = "#N/D";
                            ContemFalha = true;
                        }
                        else
                            Checado = "OK";
                    }

                    TabelaSistema[i, 0] = salario.RE.ToString();
                    TabelaSistema[i, 1] = salario.Nome;
                    TabelaSistema[i, 2] = Checado;
                }
                if (ContemFalha)
                {
                    using (StreamWriter write = new StreamWriter(string.Format("{0}\\Planilha.html", Caminho)))
                        write.Write(MontaHTML(TabelaSistema));
                    GeraArquivo = true;
                }
            }
            #endregion

            if (GeraArquivo)
            {
                try
                {
                    ZipFile.CreateFromDirectory(Caminho, string.Format("{0}\\Inconsistencia.zip", Caminho));
                }
                catch
                {
                }


                return string.Format("{0}\\Inconsistencia.zip", Caminho);
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
<html>
    <head>
        <Title>
            Demonstrativo Automatico
        </Title>
    </head>
    <body>
        <table>
            <tr>
                <td><b>Matricula</b></td>
                <td><b>Nome</b></td>
                <td style='text-align:right;'><b>Valor</b></td>
            </tr>
{0}
        </table>
    </body>
</html>", sbGrid.ToString()));
            #endregion

            return sbHTML.ToString();
        }
    }


}
