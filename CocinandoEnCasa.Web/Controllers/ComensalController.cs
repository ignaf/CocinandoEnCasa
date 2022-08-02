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
    [Authorize(Roles = "Comensal")]
    public class ComensalController : Controller
    {
        private IEventoService _eventoService;
        private IComensalService _comensalService;

        public ComensalController(IEventoService eventoService, IComensalService comensalService)
        {
            _eventoService = eventoService;
            _comensalService = comensalService;
        }

        public IActionResult Home()
        {
            return View();
        }

        public ActionResult ListarPendientes()
        {
            _eventoService.FinalizarEventos();
            List<Evento> eventos = _eventoService.FiltrarEventosConDisponibilidad();

            return View(eventos);
        }

        public ActionResult MisReservas()
        {
           
            return View();
        }

        [Route("Comensal/ReservarEvento/{idEvento}")]
        public ActionResult ReservarEvento(int idEvento)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);

            ViewBag.IdEvento = idEvento;
            ViewBag.IdUsuario = idUsuario;

            return View();
        }

        [HttpPost]
        public ActionResult ReservarEvento(Evento evento)
        {
            return View();
        }

        public ActionResult Calificar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Calificar(Evento evento)
        {
            return View();
        }
    }
}
