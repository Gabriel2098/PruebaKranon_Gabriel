using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        NLibros nLibros = new NLibros();

        [HttpGet]
        public List<Libros> Get()
        {
            return nLibros.GetLibros();
        }

        // GET api/<LibrosController>/5
        [HttpGet("{condicion}")]
        public List<Libros> Get(string condicion)
        {
            return nLibros.GetLibros(condicion);
        }

        // POST api/<LibrosController>
        [HttpPost]
        public string Post(Libros libro)
        {
            return nLibros.AddLibro(libro);
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{condicion}")]
        public string Put(string condicion, Libros libro)
        {
            return nLibros.UpdateLibro(condicion, libro);
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{condicion}")]
        public string Delete(string condicion)
        {
            return nLibros.DeleteLibro(condicion);
        }
    }
}
