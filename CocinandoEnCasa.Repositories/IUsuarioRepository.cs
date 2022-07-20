using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Repositories
{
    public interface IUsuarioRepository
    {
        public void Registrar(Usuario usuario);
        public List<String> ObtenerMails();
        public void SaveChanges();

        public Usuario BuscarMailYPassword(string email, string password);
    }
}
