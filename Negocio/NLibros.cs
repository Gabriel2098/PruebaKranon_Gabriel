using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NLibros
    {
        public DLibros dLibros = new DLibros();

        public List<Libros> GetLibros()
        {
            return dLibros.GetLibros();
        }
        public List<Libros> GetLibros(string condicion)
        {
            return dLibros.GetLibros(condicion);
        }

        public string AddLibro(Libros libro)
        {
            return dLibros.AddLibro(libro);
        }

        public string UpdateLibro(string condicion, Libros libro)
        {
            return dLibros.UpdateLibro(condicion, libro);
        }

        public string DeleteLibro(string condicion)
        {
            return dLibros.DeleteLibro(condicion);
        }
    }
}
