using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Fornecedor : Base
    {
        public Fornecedor()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
    , ProcedureAlterar = "SPUFornecedor"
    , ProcedureInserir = "SPIFornecedor"
    , ProcedureRemover = "SPDFornecedor"
    , ProcedureListarTodos = "SPSFornecedor"
    , ProcedureSelecionar = "SPSFornecedorPelaPK")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
    }
}
