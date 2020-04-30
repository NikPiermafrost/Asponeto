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
                var tmp = new AnswerLibro();
                tmp.LibroId = item.LibroId;
                tmp.Titolo = item.Titolo;
                tmp.AnnoPub = item.AnnoPub;
                tmp.Prezzo = item.Prezzo;
                tmp.Sconto = item.Sconto;
                if (item.Libreria != null)
                {
                    tmp.NomeLibreria = item.Libreria.NomeLibreria;
                    tmp.Luogo = item.Libreria.Luogo;
                }
                tmp.Autori = new List<AnswerAutore>();
                if (item.LibroAutores.Any())
                {
                    tmp.Autori = item.LibroAutores.Select(x => new AnswerAutore 
                    {
                        AutoreId = x.Autore.AutoreId,
                        Nome = x.Autore.Nome,
                        Cognome = x.Autore.Cognome
                    }).ToList();
                }
                res.Add(tmp);
            }
            return res;
        }
    }
}
