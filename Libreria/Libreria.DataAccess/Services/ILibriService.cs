﻿using Libreria.DataAccess.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libreria.DataAccess.Services
{
    public interface ILibriService
    {
        Task<List<Libro>> GetLibro();
    }
}