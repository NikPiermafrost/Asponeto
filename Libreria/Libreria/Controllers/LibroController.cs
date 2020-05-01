using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public LibroController(ILibriService libriService)
        {
            _libriService = libriService;
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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Libro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
