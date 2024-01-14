using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OCR_FE.Services
{
    public class ChatGPTService : IChatGPTService
    {
        // Your existing code...

        public async Task<string> ProcessImageAsync(string imagePath)
        {
            // Implementation of the method goes here...
            throw new NotImplementedException();
        }
    }
    public interface IChatGPTService
    {
        Task<string> ProcessImageAsync(string imagePath);
    }
}
