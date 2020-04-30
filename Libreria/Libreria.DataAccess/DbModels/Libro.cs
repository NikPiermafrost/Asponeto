using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DataAccess.DbModels
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }
        public string Titolo { get; set; }
        public int LibreriaId { get; set; }
        public DateTime AnnoPub { get; set; }
        public decimal Prezzo { get; set; }
        public int? Sconto { get; set; }
        public virtual Libreriaa Libreria { get; set; }
        public virtual List<LibroAutore> LibroAutores { get; set; }
    }
}
