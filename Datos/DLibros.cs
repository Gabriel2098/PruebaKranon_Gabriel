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
        private string _json = "";
        private List<Libros> _lstLibros = new List<Libros>();

        public List<Libros> GetLibros(string condicion)
        {
            List<Libros> _lstResult = new List<Libros>();
            DateTime fecha;
            try
            {
                StreamReader streamReader = new StreamReader(@"BDLibros.json");
                _json = streamReader.ReadToEnd();
                streamReader.Close();
                _lstLibros = JsonConvert.DeserializeObject<List<Libros>>(_json);
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

        public void AddLibro(Libros libro)
        {

        }
    }
}
