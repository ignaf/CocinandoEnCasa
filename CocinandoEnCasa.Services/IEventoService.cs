using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services
{
    public interface IEventoService
    {
        
        public bool CancelarEvento(int idEvento, int idCocineroLogueado);

        public bool ValidarFechaCancelacion(DateTime fechaEvento);

        public void FinalizarEventos();
    }
}
