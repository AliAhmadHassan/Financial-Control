using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class FuncionarioProvisoes:Base
    {
        public FuncionarioProvisoes()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUFuncionarioProvisoes"
            , ProcedureInserir = "SPIFuncionarioProvisoes"
            , ProcedureRemover = "SPDFuncionarioProvisoes"
            , ProcedureListarTodos = "SPSFuncionarioProvisoes"
            , ProcedureSelecionar = "SPSFuncionarioProvisoesPelaPK")]
        public int Id { get; set; }
        public int IdControleAcesso { get; set; }
        public decimal Ferias { get; set; }
        public decimal DecimoTerceiro { get; set; }
        public decimal INSSFerias { get; set; }
        public decimal FGTSFerias { get; set; }
        public decimal INSS13Salario { get; set; }
        public decimal FGTS13Salario { get; set; }
        public decimal ReclamacoesTrabalhistas { get; set; }
    }
}
