using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous_NoSQL.Domains;
using Nyous_NoSQL.Interfaces;

namespace Nyous_NoSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventosRepositories _eventoRepositories;

        public EventosController(IEventosRepositories eventosRespository)
        {
            _eventoRepositories = eventosRespository;
        }


        [HttpPost]
        public ActionResult<EventoDomain> Create(EventoDomain evento)
        {
            try
            {
                _eventoRepositories.Adcionar(evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            try
            {
                return _eventoRepositories.Listar();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<List<EventoDomain>> GetById(string id)
        {
            try
            {
                var evento = _eventoRepositories.BuscarPorId(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {

                _eventoRepositories.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento)
        {
            try
            {
                evento.Id = id;
                _eventoRepositories.Atualizar(id, evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
