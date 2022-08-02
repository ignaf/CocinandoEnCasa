using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services
{
    public interface IUsuarioService
    {
        public void Registrar(UsuarioViewModel usuariovm);
        public bool CompararMails(string email);
        public Usuario VerificarLogin(string email, string password);

        public List<Evento> VerEventosPendientes();
    }
}
