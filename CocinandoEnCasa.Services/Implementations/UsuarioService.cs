using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public bool CompararMails(string email)
        {
            if (_usuarioRepo.ObtenerMails().Contains(email)){
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Registrar(Usuario usuario)
        {
            _usuarioRepo.Registrar(usuario);
            _usuarioRepo.SaveChanges();
        }

        public Usuario VerificarLogin(string email, string password)
        {
            return _usuarioRepo.BuscarMailYPassword(email, password);
        }
    }
}
