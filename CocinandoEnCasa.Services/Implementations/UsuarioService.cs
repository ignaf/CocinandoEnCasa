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
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepo;
        private IEventoRepository _eventoRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo, IEventoRepository eventoRepo)
        {
            _usuarioRepo = usuarioRepo;
            _eventoRepo = eventoRepo;
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

        public void Registrar(UsuarioViewModel usuariovm)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = usuariovm.Nombre;
            usuario.Email = usuariovm.Email;
            usuario.Perfil = usuariovm.Perfil;
            usuario.Password = usuariovm.Password;
            usuario.FechaRegistracion = DateTime.Parse(DateTime.Now.ToString());
            _usuarioRepo.Registrar(usuario);
            _usuarioRepo.SaveChanges();
        }

        public List<Evento> VerEventosPendientes()
        {
            return _eventoRepo.ListarPendientes();
        }

        public Usuario VerificarLogin(string email, string password)
        {
            return _usuarioRepo.BuscarMailYPassword(email, password);
        }
    }
}
