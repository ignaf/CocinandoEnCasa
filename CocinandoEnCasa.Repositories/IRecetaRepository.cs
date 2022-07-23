using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories
{
    public interface IRecetaRepository
    {
        public List<TipoReceta> ObtenerTiposReceta();
        public void Registrar(Receta receta);

        public List<Receta> Listar();

        public List<Receta> ListarPorCocinero(int idCocinero);
        public void SaveChanges();
    }
}
