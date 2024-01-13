using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OCR_FE.Services
{
    public class ChatGPTService : IChatGPTService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";

        public ChatGPTService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Retrieve the API key from a secure location like an environment variable
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<string> ProcessTextAsync(string text)
        {
            // Prepare the JSON payload with the text
            var payload = new
            {
                prompt = text,
                max_tokens = 100 // You can adjust the number of tokens as needed
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(payload),
                Encoding.UTF8,
                "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_apiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    return $"API call failed: {response.StatusCode}";
                }

                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                return $"Error calling API: {ex.Message}";
            }
        }
    }
}
