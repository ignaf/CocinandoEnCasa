using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services
{
    public interface ICocineroService
    {
        public List<TipoReceta> ObtenerTiposReceta();
        public void RegistrarReceta(RecetaViewModel recetavm, int idCocinero);

        public void RegistrarEventoSinRecetas(EventoViewModel evento, int idCocinero);

        public void AsignarRecetasAEvento(int idEvento, int idReceta);
        public List<Receta> ObtenerRecetasCocinero(int idCocinero);
    }
}
