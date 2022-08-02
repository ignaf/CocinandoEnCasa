using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories.Implementations
{
    public class EventoRepository : IEventoRepository
    {
        _CocinandoEnCasaDbContext _ctx;
        public EventoRepository(_CocinandoEnCasaDbContext ctx)
        {
            _ctx = ctx;
        }

        public int buscarIdEventoCreado(int idCocinero)
        {
            int max = _ctx.Eventos.Max(e => e.IdEvento);
            Evento ev = _ctx.Eventos.Where(e => e.IdEvento == max && e.IdCocinero == idCocinero).FirstOrDefault();
            return ev.IdEvento;
        }

        public Evento BuscarPorId(int idEvento)
        {
            return _ctx.Eventos.Where(e => e.IdEvento == idEvento).FirstOrDefault();
        }

        public void CancelarEvento(int idEvento)
        {
           Evento eventoACancelar = _ctx.Eventos.Where(e => e.IdEvento == idEvento).FirstOrDefault();
            eventoACancelar.Estado = 0; //cancelado

        }

        public void FinalizarEventos()
        {
            List<Evento> eventos = ListarPendientes();
            foreach(var e in eventos)
            {
                if(e.Fecha.Date < DateTime.Today || e.Fecha.Date == DateTime.Today && e.Fecha.TimeOfDay > DateTime.Today.TimeOfDay)
                {
                    e.Estado = 2; //finalizado
                }
            }
            SaveChanges();
        }

        public void guardarEvento(Evento evento)
        {
            _ctx.Add(evento);
        }

        public void guardarRecetasEnEvento(EventosReceta eventosReceta)
        {
            _ctx.Add(eventosReceta);
            Evento evento = _ctx.Eventos.Where(e => e.IdEvento == eventosReceta.IdEvento).FirstOrDefault();
            evento.EventosReceta.Add(eventosReceta);

        }

        public List<Evento> ListarCancelados()
        {
            return _ctx.Eventos.Where(e => e.Estado == 0).ToList();

        }

        public List<Evento> ListarFinalizados()
        {
            return _ctx.Eventos.Where(e => e.Estado == 2).ToList();

        }

        public List<Evento> ListarPendientes()
        {
            return _ctx.Eventos.Where(e => e.Estado == 1).ToList();
        }

        public List<Evento> ListarPorCocinero(int idCocinero)
        {
            return _ctx.Eventos.Where(e => e.IdCocinero == idCocinero).ToList();
        }

        public List<Evento> ListarTodos()
        {
            return _ctx.Eventos.ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
