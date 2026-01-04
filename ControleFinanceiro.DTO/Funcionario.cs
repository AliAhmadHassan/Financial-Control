using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Funcionario: Base
    {
        public Funcionario()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUFuncionario"
            , ProcedureInserir = "SPIFuncionario"
            , ProcedureRemover = "SPDFuncionario"
            , ProcedureListarTodos = "SPSFuncionario"
            , ProcedureSelecionar = "SPSFuncionarioPelaPK")]
        public int Id { get; set; }

        public int IdControleAcesso { get; set; }

        public decimal DespesaSalario { get; set; }

        public decimal DespesaAjudaCusto { get; set; }

        public decimal DespesaFerias { get; set; }

        public decimal Despesa13Salario { get; set; }

        public decimal DespesaFGTS { get; set; }

        public decimal DespesaINSS { get; set; }

        public decimal DespesaMultaRescisorias { get; set; }

        public decimal DespesaIndenizacoes { get; set; }

        public decimal ProvisaoFerias { get; set; }

        public decimal Provisao13Salario { get; set; }

        public decimal ProvisaoINSSFerias { get; set; }

        public decimal ProvisaoFGTSFerias { get; set; }

        public decimal ProvisaoINSS13Salario { get; set; }

        public decimal ProvisaoFGTS13Salario { get; set; }

        public decimal ProvisaoReclamacoes { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; } 
    }
}
