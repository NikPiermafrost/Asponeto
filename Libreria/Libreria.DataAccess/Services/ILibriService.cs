using Libreria.DataAccess.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libreria.DataAccess.Services
{
    public interface ILibriService
    {
        Task<List<Libro>> GetLibri();
        Task<Libro> GetLibro(int Id);
        Task<Libro> GetLibroByTitolo(string titolo);
        Task<Libreriaa> CheckLibreria(string Nome, string Luogo);
        Task<Autore> CheckAutore(string Nome, string Congome);
        Task<int> AddLibroToDb(Libro libro);
        Task<bool> UpdateLibro(Libro libro);
        Task<bool> DeleteLibro(int LibroId);
    }
}