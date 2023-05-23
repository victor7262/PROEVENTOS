using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _eventos = new Evento[]
        {
            new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
            },
            new Evento()
            {
                EventoId = 2,
                Tema = "React e .NET 5",
                Local = "Juiz De Fora",
                Lote = "1º Lote",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
            }
        };

        public EventoController()
        {       
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _eventos.Where(evento => evento.EventoId == id);
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