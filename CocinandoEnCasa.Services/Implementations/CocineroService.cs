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
    public class CocineroService : ICocineroService
    {
        private IRecetaRepository _recetaRepo;
        private IEventoRepository _eventoRepo;
        public CocineroService(IRecetaRepository recetaRepo, IEventoRepository eventoRepo)
        {
            _recetaRepo = recetaRepo;
            _eventoRepo = eventoRepo;
        }



        public List<Receta> ObtenerRecetasCocinero(int idCocinero)
        {
            return _recetaRepo.ListarPorCocinero(idCocinero);
        }

        public List<TipoReceta> ObtenerTiposReceta()
        {
            return _recetaRepo.ObtenerTiposReceta();
        }

        public void RegistrarEventoSinRecetas(EventoViewModel eventovm, int idCocinero)
        {
            Evento evento = new Evento();
            evento.Nombre = eventovm.Nombre;
            evento.IdCocinero = idCocinero;
            evento.Fecha = Convert.ToDateTime(eventovm.Fecha);
            evento.Ubicacion = eventovm.Ubicacion;
            evento.Precio = eventovm.Precio;
            evento.CantidadComensales = eventovm.CantidadComensales;
            evento.Estado = 1; //pendiente
            evento.Foto = "test";
            _eventoRepo.guardarEvento(evento);
            _eventoRepo.SaveChanges();
        }
        public void AsignarRecetasAEvento(EventoViewModel eventovm, int idCocinero)
        {
            foreach (var id in eventovm.IdsRecetas)
            {
                EventosReceta er = new EventosReceta();
                er.IdEvento = _eventoRepo.buscarIdEventoCreado(idCocinero);
                er.IdReceta = int.Parse(id);
                _eventoRepo.guardarRecetasEnEvento(er);

            }

            _eventoRepo.SaveChanges();

        }

        public void RegistrarReceta(RecetaViewModel recetavm, int idCocinero)
        {
            Receta receta = new Receta();
            receta.Nombre = recetavm.Nombre;
            receta.Ingredientes = recetavm.Ingredientes;
            receta.Descripcion = recetavm.Descripcion;
            receta.TiempoCoccion = recetavm.TiempoCoccion;
            receta.IdTipoReceta = recetavm.IdTipoReceta;
            receta.IdCocinero = idCocinero;
            _recetaRepo.Registrar(receta);
            _recetaRepo.SaveChanges();
        }

        public List<Evento> ObtenerEventosCocinero(int idCocinero)
        {
            return _eventoRepo.ListarPorCocinero(idCocinero);
        }
    }
}
