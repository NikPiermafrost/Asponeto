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

        public async Task<Libro> GetLibroByTitolo(string titolo)
        {
            return await _libreriaContext.Libro.FirstOrDefaultAsync(x => x.Titolo.Trim().ToLower() == titolo.Trim().ToLower());
        }

        public async Task<Libreriaa> CheckLibreria(string Nome, string Luogo)
        {
            var res = await _libreriaContext.Libreriaa
                .FirstOrDefaultAsync(x => x.NomeLibreria.Trim().ToLower() == Nome.Trim().ToLower()
                    && x.Luogo.Trim().ToLower() == Luogo.Trim().ToLower());
            if (res != null)
            {
                return res;
            }
            else
            {
                var ToInsert = new Libreriaa();
                ToInsert.NomeLibreria = Nome;
                ToInsert.Luogo = Luogo;
                _libreriaContext.Libreriaa.Add(ToInsert);
                await _libreriaContext.SaveChangesAsync();
                return await _libreriaContext.Libreriaa.FirstOrDefaultAsync(x => x.NomeLibreria == ToInsert.NomeLibreria && x.Luogo == ToInsert.Luogo);
            }
        }

        public async Task<Autore> CheckAutore(string Nome, string Congome)
        {
            var res = await _libreriaContext.Autore.FirstOrDefaultAsync(x => x.Nome.Trim().ToLower() == Nome.ToLower().Trim()
                && x.Cognome.Trim().ToLower() == Congome.Trim().ToLower());
            if (res != null)
            {
                return res;
            }
            else
            {
                var ToInsert = new Autore();
                ToInsert.Nome = Nome;
                ToInsert.Cognome = Congome;
                _libreriaContext.Autore.Add(ToInsert);
                await _libreriaContext.SaveChangesAsync();
                return await _libreriaContext.Autore.FirstOrDefaultAsync(x => x.Nome == ToInsert.Nome && x.Cognome == ToInsert.Cognome);
            }
        }

        public async Task<int> AddLibroToDb(Libro libro)
        {
            try
            {
                _libreriaContext.Libro.Add(libro);
                await _libreriaContext.SaveChangesAsync();
                var res = await _libreriaContext.Libro.FirstOrDefaultAsync(x => x.Titolo.ToLower().Trim() == libro.Titolo.ToLower().Trim());
                return res.LibroId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> UpdateLibro(Libro libro)
        {
            try
            {
                var isMod = false;
                var toMod = _libreriaContext.Libro.FirstOrDefault(x => x.LibroId == libro.LibroId);
                if (toMod != null)
                {
                    if (toMod.Titolo != libro.Titolo)
                    {
                        toMod.Titolo = libro.Titolo;
                        isMod = true;
                    }
                    if (toMod.LibreriaId != libro.LibreriaId)
                    {
                        toMod.LibreriaId = libro.LibreriaId;
                        isMod = true;
                    }
                    if (toMod.AnnoPub != libro.AnnoPub)
                    {
                        toMod.LibreriaId = libro.LibreriaId;
                        isMod = true;
                    }
                    if (toMod.Prezzo != libro.Prezzo)
                    {
                        toMod.Prezzo = libro.Prezzo;
                        isMod = true;
                    }
                    if (toMod.Sconto != libro.Sconto)
                    {
                        toMod.Sconto = libro.Sconto;
                        isMod = true;
                    }
                    if (isMod)
                    {
                        _libreriaContext.Update(toMod);
                        await _libreriaContext.SaveChangesAsync();
                    }
                }
                return isMod;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteLibro(int LibroId)
        {
            try
            {
                var toDel = _libreriaContext.Libro.Include(x => x.LibroAutores).FirstOrDefaultAsync(x => x.LibroId == LibroId);
                if (toDel != null)
                {
                    _libreriaContext.Remove(toDel);
                    await _libreriaContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
