using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Dto
{
    public class RequestLibro
    {
        public string Titolo { get; set; }
        public DateTime AnnoPub { get; set; }
        public decimal Prezzo { get; set; }
        public int? Sconto { get; set; }
        public string NomeLibreria { get; set; }
        public string Luogo { get; set; }
        public string NomeAutore { get; set; }
        public string CognomeAutore { get; set; }
    }
}
