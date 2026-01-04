using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DTO
{
    public class ExportaListaFuncionarios
    {
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 0)]
        public string Matricula { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 1)]
        public string Nome { get; set; }
    }
}
