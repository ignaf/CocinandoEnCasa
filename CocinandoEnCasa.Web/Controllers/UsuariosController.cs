using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.Services;
using CocinandoEnCasa.ViewModels;
using CocinandoEnCasa.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CocinandoEnCasa.Web.Controllers
{
    public class UsuariosController : Controller
    {

        private IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
 

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(UsuarioViewModel usuariovm)
        {
            if (_usuarioService.CompararMails(usuariovm.Email))
            {
                ViewBag.Msg = "La dirección de Email ya se encuentra registrada";
                return View();
            }
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = usuariovm.Nombre;
                usuario.Email = usuariovm.Email;
                usuario.Perfil = usuariovm.Perfil;
                usuario.Password = usuariovm.Password;
                usuario.FechaRegistracion = DateTime.Parse(DateTime.Now.ToString());
                _usuarioService.Registrar(usuario);
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Registro));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            /*servicioUsuario.login(usuario)*/
            return RedirectToAction(nameof(Default)); /*redirigir al menu correspondiente*/
        }

        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Default)); 
        }

    }
}
