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
        public CocineroService(IRecetaRepository recetaRepo)
        {
            _recetaRepo = recetaRepo;
        }

        public List<Receta> ObtenerRecetasCocinero(int idCocinero)
        {
            return _recetaRepo.ListarPorCocinero(idCocinero);
        }

        public List<TipoReceta> ObtenerTiposReceta()
        {
            return _recetaRepo.ObtenerTiposReceta();
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
    }
}
