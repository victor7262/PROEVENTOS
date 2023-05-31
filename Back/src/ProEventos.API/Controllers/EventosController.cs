using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {       
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(
                evento => evento.Id == id
            );
        }


        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{Id}")]
        public string Put(string id)
        {
            return "Exemplo de Put: " + id;
        }

        [HttpDelete("{Id}")]
        public string Delete(string id)
        {
            return "Exemplo de Delete: " + id;
        }
    }
}