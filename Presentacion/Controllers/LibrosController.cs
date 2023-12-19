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
        

        // GET api/<LibrosController>/5
        [HttpGet]
        public List<Libros> Get(string condicion)
        {
            return nLibros.GetLibros(condicion);
        }

        // POST api/<LibrosController>
        [HttpPost]
        public void Post(Libros libro)
        {
            nLibros.AddLibro(libro);
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
