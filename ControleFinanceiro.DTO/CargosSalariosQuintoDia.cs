using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class CargosSalariosQuintoDia
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
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=9)]
        public decimal Convenio { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=10)]
        public decimal Farmacia { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=11)]
        public string HoraExtra60 { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 12)]
        public string HoraExtra80 { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 13)]
        public string HoraExtra100 { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 14)]
        public string AdicionalNoturno { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 15)]
        public string Premiacao { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 21)]
        public string TotalLiquido { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 22)]
        public string Banco { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 23)]
        public string Equipe { get; set; }

    }
}
