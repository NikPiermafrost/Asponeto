using Libreria.Dto;
using System.Threading.Tasks;

namespace Libreria.Core
{
    public interface ILibroCore
    {
        Task<int> PostLibro(RequestLibro requestLibro);
    }
}