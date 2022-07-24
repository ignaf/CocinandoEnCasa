using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories
{
    public interface IEventoRepository
    {
        public void guardarEvento(Evento evento);
        public void guardarRecetasEnEvento(EventosReceta eventosReceta);
        public void SaveChanges();
    }
}
