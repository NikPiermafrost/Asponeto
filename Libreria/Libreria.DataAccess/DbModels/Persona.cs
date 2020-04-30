using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DataAccess.DbModels
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }
}
