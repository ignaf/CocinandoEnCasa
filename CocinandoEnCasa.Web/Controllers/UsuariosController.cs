using CocinandoEnCasa.Data.models;
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
 

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuario usuario)
        {
            /*servicioUsuario.registrar(usuario)*/
            return RedirectToAction(nameof(Default));
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
