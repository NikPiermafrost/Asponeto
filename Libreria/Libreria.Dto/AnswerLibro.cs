using Libreria.DataAccess.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Libreria.Dto
{
    public class AnswerLibro
    {
        public int LibroId { get; set; }
        public string Titolo { get; set; }
        public DateTime AnnoPub { get; set; }
        public decimal Prezzo { get; set; }
        public int? Sconto { get; set; }
        public string NomeLibreria { get; set; }
        public string Luogo { get; set; }
        public List<AnswerAutore> Autori { get; set; }

        public static List<AnswerLibro> MappaPerLista(List<Libro> libri)
        {
            var res = new List<AnswerLibro>();
            foreach (var item in libri)
            {
                res.Add(MappaLibro(item));
            }
            return res;
        }

        public static AnswerLibro MappaLibro(Libro libro)
        {
            var tmp = new AnswerLibro();
            tmp.LibroId = libro.LibroId;
            tmp.Titolo = libro.Titolo;
            tmp.AnnoPub = libro.AnnoPub;
            tmp.Prezzo = libro.Prezzo;
            tmp.Sconto = libro.Sconto;
            if (libro.Libreria != null)
            {
                tmp.NomeLibreria = libro.Libreria.NomeLibreria;
                tmp.Luogo = libro.Libreria.Luogo;
            }
            tmp.Autori = new List<AnswerAutore>();
            if (libro.LibroAutores.Any())
            {
                tmp.Autori = libro.LibroAutores.Select(x => new AnswerAutore
                {
                    AutoreId = x.Autore.AutoreId,
                    Nome = x.Autore.Nome,
                    Cognome = x.Autore.Cognome
                }).ToList();
            }
            return tmp;
        }
    }
}
