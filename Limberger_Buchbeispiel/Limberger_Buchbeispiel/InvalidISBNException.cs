using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limberger_Buchbeispiel
{
    class InvalidISBNException:Exception
    {
        public InvalidISBNException() : base()
        {

        }
        public InvalidISBNException(string ISBNNummer) : base(ISBNNummer + " es handelt sich um keine gültige ISBNNummer")
        {

        }
        public InvalidISBNException(string message, string ISBNNummer) : base(ISBNNummer + " es handelt sich um keine gültige ISBNNummer" + message)
        {

        }
        public InvalidISBNException(string message, string ISBNNummer, Exception inner) : base(ISBNNummer + " es handelt sich um keine gültige ISBNNummer" + message, inner)
        {

        }
    }
}
