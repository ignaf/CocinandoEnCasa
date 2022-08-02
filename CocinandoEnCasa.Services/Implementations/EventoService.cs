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

        public void FinalizarEventos()
        {
            _eventoRepo.FinalizarEventos();
        }

        public List<Evento> ListarCancelados()
        {
            return _eventoRepo.ListarCancelados();
        }

        public List<Evento> ListarFinalizados()
        {
            return _eventoRepo.ListarFinalizados();
        }

        public List<Evento> ListarPendientes()
        {
            return _eventoRepo.ListarPendientes();
        }

        public List<Evento> ListarTodos()
        {
            return _eventoRepo.ListarTodos();
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
