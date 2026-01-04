using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class FuncionarioDespesas:Base
    {
        public FuncionarioDespesas()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUFuncionarioDespesas"
            , ProcedureInserir = "SPIFuncionarioDespesas"
            , ProcedureRemover = "SPDFuncionarioDespesas"
            , ProcedureListarTodos = "SPSFuncionarioDespesas"
            , ProcedureSelecionar = "SPSFuncionarioDespesasPelaPK")]
        public int Id { get; set; }
        public int IdControleAcesso { get; set; }
        public decimal Salario { get; set; }
        public decimal AjudaCusto { get; set; }
        public decimal Ferias { get; set; }
        public decimal DecimoTerceiro { get; set; }
        public decimal FGTS { get; set; }
        public decimal INSS { get; set; }
        public decimal MultaRescisorias { get; set; }
        public decimal Indenizacoes { get; set; }
        public decimal Extra { get; set; }
    }
}
