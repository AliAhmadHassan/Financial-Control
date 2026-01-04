using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class CarteiraTipo
    {
        public List<DTO.CarteiraTipo> Select()
        {
            return new DAL.CarteiraTipo().Select();
        }
    }
}
