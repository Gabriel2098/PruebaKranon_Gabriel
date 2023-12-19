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
        public List<Libros> GetLibros(string condicion)
        {
            return dLibros.GetLibros(condicion);
        }

        public void AddLibro(Libros libro)
        {
            dLibros.AddLibro(libro);
        }

        public void UpdateLibro(string condicion, Libros libro)
        {
            dLibros.UpdateLibro(condicion, libro);
        }

        public void DeleteLibro(string condicion)
        {
            dLibros.DeleteLibro(condicion);
        }
    }
}
