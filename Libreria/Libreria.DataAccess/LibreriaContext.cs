using Libreria.DataAccess.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Libreria.DataAccess
{
    public class LibreriaContext: DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options): base(options) { }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Libreriaa> Librerias { get; set; }
        public DbSet<LibroAutore> LibroAutores { get; set; }
        public DbSet<Autore> Autores { get; set; }
    }
}
