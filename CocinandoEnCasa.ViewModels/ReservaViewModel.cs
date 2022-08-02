using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.ViewModels
{
    public class ReservaViewModel
    {
        public int IdReceta { get; set; }
        public int CantidadComensales { get; set; }
    }
}
