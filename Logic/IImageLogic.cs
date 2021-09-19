using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public interface IImageLogic
    {
        Task<string> SaveImage(IFormFile image);
    }
}