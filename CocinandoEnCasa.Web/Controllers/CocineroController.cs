﻿using CocinandoEnCasa.Data.models;
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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CocinandoEnCasa.Web.Controllers
{
    [Authorize(Roles = "Cocinero")]
    public class CocineroController : Controller
    {
        private ICocineroService _cocineroService;
        private IEventoService _eventoService;
        private _CocinandoEnCasaDbContext _ctx;

        public CocineroController(ICocineroService cocineroService, _CocinandoEnCasaDbContext context, IEventoService eventoService)
        {
            _cocineroService = cocineroService;
            _ctx = context;
            _eventoService = eventoService;
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
        public ActionResult ListarEventos()
        {
            _eventoService.FinalizarEventos();

            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);

            List<Evento> eventos = _cocineroService.ObtenerEventosCocinero(idUsuario);

            return View(eventos);
        }
        public ActionResult Perfil()
        {

            return View();
        }

        public ActionResult CrearEvento()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);

            ViewBag.Recetas = _cocineroService.ObtenerRecetasCocinero(idUsuario).Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdReceta.ToString()
            });
            return View();
        }

        [HttpPost]
        public ActionResult CrearEvento(EventoViewModel evento)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);
            if (ModelState.IsValid)
            {


                _cocineroService.RegistrarEventoSinRecetas(evento, idUsuario);
                _cocineroService.AsignarRecetasAEvento(evento, idUsuario);


                return RedirectToAction(nameof(ListarRecetas));
            }
            ViewBag.Recetas = _cocineroService.ObtenerRecetasCocinero(idUsuario).Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.IdReceta.ToString()
            });

            return View();

        }


        [Route("Cocinero/CancelarEvento/{idEvento}")]
        public ActionResult CancelarEvento(int idEvento)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            var claimbuscado = claims.First(c => c.Type == "IdUsuario");
            int idUsuario = int.Parse(claimbuscado.Value);

            if(_cocineroService.CancelarEvento(idEvento, idUsuario))
            {
                return RedirectToAction(nameof(ListarEventos));
            }

            
            return View();
        }

    } 
}
