using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class DespesaRateio : Base
    {
        public DespesaRateio()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDespesasRateio"
            , ProcedureInserir = "SPIDespesasRateio"
            , ProcedureRemover = "SPDDespesasRateio"
            , ProcedureListarTodos = "SPSDespesasRateio"
            , ProcedureSelecionar = "SPSDespesasRateioPelaPK")]
        public int Id { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime Emissao { get; set; }
        public int IdUsuario { get; set; }
        public decimal Valor { get; set; }
        public int IdDadosBancario { get; set; }
        public int NumeroDocumento { get; set; }
        public decimal IRPJ { get; set; }
        public decimal Cofins { get; set; }
        public decimal CSLL { get; set; }
        public decimal PIS { get; set; }
        public decimal ISS { get; set; }
        public byte[] Nota { get; set; }
        public byte[] Boleto { get; set; }
        public byte[] Comprovante { get; set; }
        public DateTime DtPgto { get; set; }
        public string Descricao { get; set; }
        public bool Dedutivel { get; set; }

        public int IdSegmento { get; set; }
        public int IdCarteira { get; set; }
        public string ExtensaoNota { get; set; }
        public string ExtensaoBoleto { get; set; }
        public string ExtensaoComprovante { get; set; }
        public int IdFornecedor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
