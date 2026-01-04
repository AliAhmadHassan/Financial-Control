using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    
    public class CargosSalariosExtraordinario
    {
        [XLSX_Planilha.AtributoXLS(Linha = 2, Coluna = 0)]
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem=0)]
        public int RE { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 1)]
        public string Nome { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 2)]
        public DateTime DataAdm { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 3)]
        public DateTime DataNasc { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 4)]
        public int Idade { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 5)]
        public DateTime Data { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 6)]
        public string CPF { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 7)]
        public string CTPS { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 8)]
        public string PIS { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 9)]
        public string RG { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 10)]
        public string Sexo { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 11)]
        public string CargaFuncao { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 12)]
        public string CentroCusto { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 13)]
        public string Equipe { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 14)]
        public string EmpresaCadastrada { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 15)]
        public string Banco { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 16)]
        public string Agencia { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 17)]
        public string Conta { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 18)]
        public string Dig { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 19)]
        public decimal SalarioBase { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 20)]
        public decimal Quinze { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 21)]
        public decimal VinteCinco { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 22)]
        public decimal ValorDiario { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 23)]
        public decimal VtPago { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 24)]
        public decimal NoveETrinta { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 25)]
        public decimal VT { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 26)]
        public decimal VRDiario { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 27)]
        public decimal VR { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 28)]
        public decimal AssistenciaMedica { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 29)]
        public decimal Bonus { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 30)]
        public decimal Trienio { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 31)]
        public decimal Extraordinario { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 32)]
        public decimal ProjetoPAE { get; set; }
        [XLSX_Coluna.AtributoXLS_Coluna(Ordem = 33)]
        public decimal TotalVencimento { get; set; }



    }
}
