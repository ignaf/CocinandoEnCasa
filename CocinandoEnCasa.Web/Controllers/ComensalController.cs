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

namespace CocinandoEnCasa.Web.Controllers
{
    [Authorize(Roles = "Comensal")]
    public class ComensalController : Controller
    {

        public ComensalController()
        {

        }

        public IActionResult Home()
        {
            return View();
        }

        public ActionResult MisReservas()
        {
           
            return View();
        }

        public ActionResult ReservarEvento()
        {
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