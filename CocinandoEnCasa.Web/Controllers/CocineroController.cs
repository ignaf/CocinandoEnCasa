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

namespace CocinandoEnCasa.Web.Controllers
{
    [Authorize(Roles ="Cocinero")]
    public class CocineroController : Controller
    {
        private ICocineroService _cocineroService;

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
            if (ModelState.IsValid)
            {
                _cocineroService.RegistrarReceta(recetavm);
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
