using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.Services;
using CocinandoEnCasa.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CocinandoEnCasa.Repositories;
using System.Security.Claims;

namespace CocinandoEnCasa.Web.Controllers
{
    [Authorize(Roles ="Cocinero")]
    public class CocineroController : Controller
    {
        private ICocineroService _cocineroService;
        private IUsuarioRepository _usuarioRepo;

        public CocineroController(ICocineroService cocineroService)
        {
            _cocineroService = cocineroService;
        }
        public ActionResult CrearReceta()
        {
            List<TipoReceta> tipos = _cocineroService.ObtenerTiposReceta();
            ViewBag.TiposReceta = tipos;
            return View();
        }

        [HttpPost]
        public ActionResult CrearReceta(RecetaViewModel recetavm)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);

            if (ModelState.IsValid)
            {
                _cocineroService.RegistrarReceta(recetavm, idUsuario);
                return RedirectToAction(nameof(ListarRecetas));
            }
            return RedirectToAction(nameof(ListarRecetas));
        }

        public ActionResult ListarRecetas()
        {
            
            return View();
        }
    }
}
