using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class ExtratoBancario
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set; }
        public string Conta { get; set; }
        public int Tipo { get; set; }
    }
}
