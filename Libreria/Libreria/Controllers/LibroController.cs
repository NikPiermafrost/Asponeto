using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Core;
using Libreria.DataAccess.DbModels;
using Libreria.DataAccess.Services;
using Libreria.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibriService _libriService;
        private readonly ILibroCore _libroCore;
        public LibroController(ILibriService libriService, ILibroCore libroCore)
        {
            _libriService = libriService;
            _libroCore = libroCore;
        }
        // GET: api/Libro
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var toMap = await _libriService.GetLibri();
                var res = AnswerLibro.MappaPerLista(toMap);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // GET: api/Libro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var toMap = await _libriService.GetLibro(id);
                if (toMap == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(AnswerLibro.MappaLibro(toMap));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // POST: api/Libro
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestLibro value)
        {
            try
            {
                var res = await _libroCore.PostLibro(value);
                if (res != 0)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // PUT: api/Libro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Libro libro)
        {
            try
            {
                libro.LibroId = id;
                var res = await _libriService.UpdateLibro(libro);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _libriService.DeleteLibro(id);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
