using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class ImportaDespesasXLS
    {
        [XLSX_Planilha.AtributoXLS(Linha = 1, Coluna = 0)]
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 0)]
        public int Matricula { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 1)]
        public string Nome { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 2)]
        public decimal Valor { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 3)]
        public string IdBanco { get; set; }
    }
}
