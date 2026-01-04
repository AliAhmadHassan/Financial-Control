using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Receita : Base
    {
        public Receita()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUReceitas"
            , ProcedureInserir = "SPIReceitas"
            , ProcedureRemover = "SPDReceitas"
            , ProcedureListarTodos = "SPSReceitas"
            , ProcedureSelecionar = "SPSReceitasPelaPK")]
        public int Id { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public int NumeroNota { get; set; }
        public decimal Valor { get; set; }
        public decimal IRPJ { get; set; }
        public decimal Cofins { get; set; }
        public decimal CSLL { get; set; }
        public decimal PIS { get; set; }
        public decimal ISS { get; set; }
        public byte[] NOTA { get; set; }
        public byte[] CartaCorrecao { get; set; }
        public bool NotaFiscal { get; set; }
        public int IdDadosBancario { get; set; }
        public DateTime Referencia { get; set; }
        public int IdUsuario { get; set; }
        public string Obs { get; set; }
        public bool Dedutivel { get; set; }
        public int IdSegmento { get; set; }
        public int IdCarteira { get; set; }
		public string ExtensaoNOTA { get; set; }
        public string ExtensaoCartaCorrecao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DtPgto { get; set; }
    }
}
