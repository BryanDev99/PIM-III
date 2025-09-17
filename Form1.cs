using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace PIMIII
{
    public partial class Form1 : Form
    {
        private static HttpClient _client = new HttpClient();
        private string _apiKey = "YOUR-API-KEY";
        private string connectionString = "Server=localhost;Database=YourDatabase;Trusted_Connection=True";

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(pictureBox1, "Clique para saber mais sobre nós!");
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

                private void Consultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Tecnicos";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
        
                string resultado = "";
        
                while (reader.Read())
                {
                    int matricula = reader.GetInt32(0);
                    string nome = reader["Nome"].ToString();
                    string email = reader["Email"].ToString();
                    string telefone = reader["Telefone"].ToString();
                    string especialidade = reader["Especialidade"].ToString();
        
                    resultado += $"Matrícula {matricula}\n" +
                        $"Nome: {nome}\n" +
                        $"Email: {email}\n" +
                        $"Telefone: {telefone}\n" +
                        $"Especialidade: {especialidade}\n" +
                        $"--------------------------------\n";
                }
        
                reader.Close();
        
                MessageBox.Show(resultado, "Técnicos disponíveis:");
            }
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nós, Axis Tecnologia, temos o objetivo de entregar aplicações simples e de fácil utilização" +
                " para a maioria dos trabalhadores!", "Sobre nós");
        }
    }
}
