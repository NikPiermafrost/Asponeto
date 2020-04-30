using Libreria.DataAccess.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Libreria.DataAccess
{
    public class LibreriaContext: DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options): base(options) { }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Libreriaa> Libreriaa { get; set; }
        public DbSet<LibroAutore> LibroAutore { get; set; }
        public DbSet<Autore> Autore { get; set; }
    }
}
