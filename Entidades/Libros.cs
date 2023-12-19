using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libros
    {
        private string bookName, author;
        private DateTime releaseDate;

        public string BookName {
            get { return bookName; }
            set { bookName = value; }
        }
        public string Author {
            get { return author; }
            set { author = value; }
        }
        public DateTime ReleaseDate {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
    }
}
