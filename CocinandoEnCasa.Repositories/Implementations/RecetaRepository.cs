using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories.Implementations
{
    public class RecetaRepository : IRecetaRepository
    {
        _CocinandoEnCasaDbContext _ctx;
        public RecetaRepository(_CocinandoEnCasaDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<TipoReceta> ObtenerTiposReceta()
        {
            return _ctx.TipoRecetas.OrderBy(t => t.Nombre).ToList();
        }

        public void Registrar(Receta receta)
        {
            _ctx.Add(receta);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
