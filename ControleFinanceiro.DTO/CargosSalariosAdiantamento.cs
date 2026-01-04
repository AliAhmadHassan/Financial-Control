using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class CargosSalariosAdiantamento
    {
        [XLSX_Planilha.AtributoXLS(Linha = 1, Coluna = 0)]
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=0)]
        public int CodLivro { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=1)]
        public string NomeFuncionario { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=2)]
        public string Agencia { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=3)]
        public string Conta { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=4)]
        public string Digito { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=5)]
        public decimal AdiantamentoSalarial { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=6)]
        public string Banco { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=7)]
        public string Equipe { get; set; }
    }
}
