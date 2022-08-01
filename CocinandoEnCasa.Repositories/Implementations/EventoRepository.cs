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

        public List<Evento> ListarPorCocinero(int idCocinero)
        {
            return _ctx.Eventos.Where(e => e.IdCocinero == idCocinero).ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
