using Libreria.DataAccess.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DataAccess.Services
{
    public class LibriService : ILibriService
    {
        private readonly LibreriaContext _libreriaContext;
        public LibriService(LibreriaContext libreriaContext)
        {
            _libreriaContext = libreriaContext;
        }

        public async Task<List<Libro>> GetLibri()
        {
            try
            {
                var result = await _libreriaContext.Libro
                    .Include(x => x.Libreria)
                    .Include(x => x.LibroAutores)
                    .ThenInclude(x => x.Autore).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Libro> GetLibro(int Id)
        {
            try
            {
                var res = await _libreriaContext.Libro
                    .Include(x => x.Libreria)
                    .Include(x => x.LibroAutores)
                    .ThenInclude(x => x.Autore)
                    .FirstOrDefaultAsync(x => x.LibroId == Id);
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
