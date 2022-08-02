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
        private IReservaRepository _reservaRepo;
        public EventoService(IEventoRepository eventoRepo, IReservaRepository reservaRepo)
        {
            _eventoRepo = eventoRepo;
            _reservaRepo = reservaRepo;
        }

        public List<Evento> FiltrarEventosConDisponibilidad()
        {
            List<Evento> filtrados = new List<Evento>();
            foreach(var evento in ListarPendientes())
            {
                List<Reserva> reservas = _reservaRepo.BuscarPorEvento(evento.IdEvento);
                int totalComensalesConReserva = 0;

                foreach(var reserva in reservas)
                {
                    totalComensalesConReserva += reserva.CantidadComensales;
                }

                if (totalComensalesConReserva < evento.CantidadComensales)
                {
                    filtrados.Add(evento);
                }

            }
            return filtrados;
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
