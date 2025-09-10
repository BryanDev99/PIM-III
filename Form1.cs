using System.Text;
using System.Text.Json;

namespace PIMIII
{
    public partial class Form1 : Form
    {
        private static HttpClient _client = new HttpClient();
        private string _apiKey = "YOUR-API-KEY";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text;
            if (string.IsNullOrWhiteSpace(userMessage)) return;

            rtbChat.AppendText("Você: " + userMessage + "\n\n");
            txtInput.Clear();

            string response = await GetChatGPTResponse(userMessage);
            rtbChat.AppendText("ChatGPT: " + response + "\n\n");
        }

        private async Task<string> GetChatGPTResponse(string message)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = message }
                }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);
            return doc.RootElement
                      .GetProperty("choices")[0]
                      .GetProperty("message")
                      .GetProperty("content")
                      .GetString()
                      .Trim();
        }
    }
}


