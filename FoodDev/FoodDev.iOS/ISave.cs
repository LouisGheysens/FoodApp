using System.IO;
using System.Threading.Tasks;

namespace FoodDev.iOS
{
    public interface ISave
    {
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}