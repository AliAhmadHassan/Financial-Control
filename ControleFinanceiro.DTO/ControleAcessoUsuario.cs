using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class ControleAcessoUsuario
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public string Nome { get; set; }

        public string Matricula { get; set; }

        public DateTime Adimissao { get; set; }

        public int IdCarteira { get; set; }
    }
}
