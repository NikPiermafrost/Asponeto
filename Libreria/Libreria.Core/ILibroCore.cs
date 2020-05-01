using Libreria.Dto;
using System.Threading.Tasks;

namespace Libreria.Core
{
    public interface ILibroCore
    {
        Task<RequestLibro> PostLibro(RequestLibro requestLibro);
    }
}