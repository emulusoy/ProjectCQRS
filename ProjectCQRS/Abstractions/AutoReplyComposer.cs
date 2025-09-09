
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ProjectCQRS.CQRS.Results.ContactResults;
using static System.Net.WebRequestMethods;

namespace ProjectCQRS.Abstractions
{
    public class AutoReplyComposer : IAutoReplyComposer
    {
        private readonly string _apiKey;
        private readonly HttpClient _http = new();

        public AutoReplyComposer(IConfiguration cfg)
        {
            _apiKey = cfg["GEMINI_API_KEY"]!;
        }
        public async Task<string> ComposeAsync(string customerMessage, CancellationToken ct = default)
        {
            var model = "gemini-1.5-pro"; 
            var url = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={_apiKey}";

            var prompt = $"Müşterinin şu mesajına kısa, net ve nazik Türkçe bir yanıt ver (2-4 cümle):\n\n{customerMessage}";

            var payload = new
            {
                contents = new[] {
                new {
                    role = "user",
                    parts = new[] { new { text = prompt } }
                }
            },
                generationConfig = new { maxOutputTokens = 120, temperature = 0.6 }
            };

            var req = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            using var res = await _http.PostAsync(url, req, ct);
            var body = await res.Content.ReadAsStringAsync(ct);
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.TryGetProperty("candidates", out var cands) &&
                    cands.ValueKind == JsonValueKind.Array && cands.GetArrayLength() > 0)
                {
                    var cand = cands[0];
                    if (cand.TryGetProperty("content", out var content) &&
                        content.TryGetProperty("parts", out var parts) &&
                        parts.ValueKind == JsonValueKind.Array && parts.GetArrayLength() > 0 &&
                        parts[0].TryGetProperty("text", out var textElem))
                    {
                        var text = textElem.GetString();
                        if (!string.IsNullOrWhiteSpace(text))
                            return text.Trim();
                    }
                }
            }
            catch {  }
            return "Mesajınızı aldık, kısa süre içinde size dönüş yapacağız. İlginiz için teşekkür ederiz.";

        }
    }
}
