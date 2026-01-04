using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Menu:Base
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        public int IdPai { get; set; }
        public string Imagem { get; set; }
    }
}
