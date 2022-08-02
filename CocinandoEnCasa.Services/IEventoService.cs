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

        public bool ValidarFechaCancelacion(DateTime fechaEvento);

        public void FinalizarEventos();

        public List<Evento> ListarFinalizados();

        public List<Evento> ListarPendientes();

        public List<Evento> ListarCancelados();

        public List<Evento> ListarTodos();

        public List<Evento> FiltrarEventosConDisponibilidad();


    }
}
