using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class ExportaListaFuncionarios
    {
        public string Exportar()
        {
            string Caminho = string.Format("{0}Inconsistencia\\ListaFuncionarios.xls", AppDomain.CurrentDomain.BaseDirectory);
            
            File.Copy(string.Format("{0}Inconsistencia\\ListaFuncionariosModelo.xls", AppDomain.CurrentDomain.BaseDirectory), Caminho, true);

            List<DTO.ControleAcessoUsuario> Grupos = new BLL.ControleAcessoUsuario().Select();
            List<DTO.ExportaListaFuncionarios> ListaFuncionarios = new List<DTO.ExportaListaFuncionarios>();
            foreach (DTO.ControleAcessoUsuario usuario in Grupos)
            {
                ListaFuncionarios.Add(new DTO.ExportaListaFuncionarios() { Matricula = usuario.Matricula, Nome = usuario.Nome });
            }

            new DAL.XLSX().ExportarParaExcel<DTO.ExportaListaFuncionarios>(ListaFuncionarios, Caminho);

            return Caminho;
        }
    }
}