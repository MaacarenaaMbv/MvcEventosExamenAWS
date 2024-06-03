using Microsoft.AspNetCore.Mvc;
using MvcEventosExamenAWS.Models;
using MvcEventosExamenAWS.Services;

namespace MvcEventosExamenAWS.Controllers
{
    public class EventosController : Controller
    {

        private ServiceApiEventos service;

        public EventosController(ServiceApiEventos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Evento evento = await this.service.FindEventoAsync(id);
            return View(evento);
        }
    
        public IActionResult EventosCategoria()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventosCategoria(int idcategoria)
        {
            List<Evento> eventos = await this.service.GetEventosCategoriaAsync(idcategoria);
            return View(eventos);
        }

    
    }

}
