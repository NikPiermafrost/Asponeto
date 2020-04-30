using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DataAccess.DbModels
{
    public class Autore
    {
        [Key]
        public int AutoreId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public virtual List<LibroAutore> LibroAutores { get; set; }
    }
}
