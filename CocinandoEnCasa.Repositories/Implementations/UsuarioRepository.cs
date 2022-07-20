using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private _CocinandoEnCasaDbContext _ctx;

        public UsuarioRepository(_CocinandoEnCasaDbContext ctx)
        {
            _ctx = ctx;
        }

        public Usuario BuscarMailYPassword(string email, string password)
        {
            return _ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<string> ObtenerMails()
        {
            List<String> listaMails = new List<String>();

            foreach(var u in (from u in _ctx.Usuarios
                              select new { u.Email }).ToList()){
                listaMails.Add(u.Email);
            }
            return listaMails;
        }

        public void Registrar(Usuario usuario)
        {
            _ctx.Add(usuario);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
