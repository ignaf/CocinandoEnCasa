using CocinandoEnCasa.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.Services
{
    public interface IUsuarioService
    {
        public void Registrar(Usuario usuario);
        public bool CompararMails(string email);
        public Usuario VerificarLogin(string email, string password);
    }
}
