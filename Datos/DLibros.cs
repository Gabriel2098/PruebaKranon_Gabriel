using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Datos
{
    public class DLibros
    {
        private string _json;
        private List<Libros> _lstLibros = new List<Libros>();
        private StreamReader _archivoRead;
        private StreamWriter _archivoWrite;
        private Libros _libro;

        public DLibros()
        {
            _archivoRead = new StreamReader("BDLibros.json");
            _json = _archivoRead.ReadToEnd();
            _archivoRead.Close();
            _lstLibros = JsonConvert.DeserializeObject<List<Libros>>(_json);
        }

        public List<Libros> GetLibros()
        {
            return _lstLibros;
        }

        public List<Libros> GetLibros(string condicion)
        {
            _json = "";
            List<Libros> _lstResult = new List<Libros>();
            DateTime fecha;
            try
            {
                if (DateTime.TryParse(condicion, out fecha))
                {
                    var releaseDate = _lstLibros.FindAll(x => x.ReleaseDate == fecha);
                    _lstResult = _lstResult.Concat(releaseDate).ToList<Libros>();
                }
                else
                {
                    var bookName = _lstLibros.FindAll(x => x.BookName == condicion);
                    var author = _lstLibros.FindAll(x => x.Author == condicion);
                    _lstResult = bookName == null ? _lstResult : _lstResult.Concat(bookName).ToList<Libros>();
                    _lstResult = author == null ? _lstResult : _lstResult.Concat(author).ToList<Libros>();
                }
                return _lstResult;
            }
            catch(Exception ex) {
                return _lstResult;
            }
        }

        private Libros GetLibro(string condicion, int operacion = 1)
        {
            Libros libro = new Libros();
            DateTime fecha;
            if (DateTime.TryParse(condicion, out fecha) && operacion == 1)
            {
                return _lstLibros.First(x => x.ReleaseDate == fecha);
            }
            else
            {
                var bookName = _lstLibros.Find(x => x.BookName == condicion);
                if (bookName != null) return bookName;
                var author = _lstLibros.Find(x => x.Author == condicion);
                return author;
            }
        }

        public string AddLibro(Libros libro)
        {
            try
            {
                _lstLibros.Add(libro);
                _archivoWrite = new StreamWriter("BDLibros.json");
                _json = JsonConvert.SerializeObject(_lstLibros);
                _archivoWrite.WriteLine($"{_json}");
                _archivoWrite.Close();
                return "Libro añadido con exito";
            }
            catch (Exception ex)
            {
                return $"Hubo un error en la inserción: {ex.Message}";
            }
        }

        public string UpdateLibro(string condicion, Libros libroUpdate)
        {
            try
            {
                _libro = GetLibro(condicion, 0);
                if (_libro == null) return "Elemento no encontrado para actualizar";
                _libro.BookName = libroUpdate.BookName;
                _libro.Author = libroUpdate.Author;
                _libro.ReleaseDate = libroUpdate.ReleaseDate;
                _json = JsonConvert.SerializeObject(_lstLibros);
                _archivoWrite = new StreamWriter("BDLibros.json");
                _archivoWrite.WriteLine($"{_json}");
                _archivoWrite.Close();
                return "Actualizado correctamente";
            }
            catch(Exception ex)
            {
                return $"Hubo un error en la actualización: {ex.Message}";
            }
        }

        public string DeleteLibro(string condicion)
        {
            try
            {
                _libro = GetLibro(condicion);
                if (_libro == null) return "Elemento no encontrado para eliminar"; ;
                _lstLibros.Remove(_libro); 
                _json = JsonConvert.SerializeObject(_lstLibros);
                _archivoWrite = new StreamWriter("BDLibros.json");
                _archivoWrite.WriteLine($"{_json}");
                _archivoWrite.Close();
                return "Eliminado correctamente";
            }
            catch(Exception ex)
            {
                return $"Hubo un error en la actualización: {ex.Message}";
            }
        }
    }
}
