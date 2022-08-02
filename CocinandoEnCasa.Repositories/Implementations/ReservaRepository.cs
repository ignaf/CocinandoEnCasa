using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories.Implementations
{
    public class ReservaRepository : IReservaRepository
    {
        _CocinandoEnCasaDbContext _ctx;
        public ReservaRepository(_CocinandoEnCasaDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Reserva> BuscarPorEvento(int idEvento)
        {
           return _ctx.Reservas.Where(r => r.IdEvento == idEvento).ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
