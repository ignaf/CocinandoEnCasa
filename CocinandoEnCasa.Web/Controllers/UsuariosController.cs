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
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
                _usuarioService.Registrar(usuariovm);
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Registro));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

            Usuario usuario = _usuarioService.VerificarLogin(email, password);
            String rol = "";
            if (usuario.Perfil == 1)
            {
                rol = "Cocinero";
            }
            else if (usuario.Perfil == 2)
            {
                rol = "Comensal";
            }

            if (usuario != null)
            {

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name ,usuario.Nombre),
                         new Claim("Email" ,usuario.Email),
                          new Claim("IdUsuario" ,usuario.IdUsuario.ToString()),
                          new Claim(ClaimTypes.Role, rol),                                         
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (rol == "Cocinero")
                {
                    return RedirectToAction("Perfil", "Cocinero");
                }
                else if (rol == "Comensal")
                {
                    return RedirectToAction("Home","Comensal");
                }
                return RedirectToAction(nameof(Login));
            }
            else
            {
                ViewBag.Msg = "Usuario o contraseña incorrectos";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Default));
        }

        

    }
}
