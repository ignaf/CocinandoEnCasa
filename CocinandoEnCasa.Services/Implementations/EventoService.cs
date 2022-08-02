using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.Repositories;
using CocinandoEnCasa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services.Implementations
{
    public class EventoService : IEventoService
    {

        private IEventoRepository _eventoRepo;
        public EventoService(IEventoRepository eventoRepo)
        {
            _eventoRepo = eventoRepo;
        }

      
        public bool CancelarEvento(int idEvento, int idCocineroLogueado)
        {
            Evento eventoACancelar = _eventoRepo.BuscarPorId(idEvento);
            if (eventoACancelar.IdCocinero == idCocineroLogueado && ValidarFechaCancelacion(eventoACancelar.Fecha))
            {
                _eventoRepo.CancelarEvento(eventoACancelar.IdEvento);
                _eventoRepo.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FinalizarEventos()
        {
            _eventoRepo.FinalizarEventos();
        }

        public bool ValidarFechaCancelacion(DateTime fechaEvento)
        {
            if (fechaEvento.Date > DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
