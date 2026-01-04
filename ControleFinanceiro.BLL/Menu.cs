using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class Menu
    {
        public virtual List<DTO.Menu> SelectPelaIdUsuario(int Id)
        {
            return new DAL.Menu().SelectPelaIdUsuario(Id);
        }
    }
}
