using System.Globalization;
using System.Text;
using System.Text.Json;

namespace ProjectCQRS.Abstractions
{
    public record TripEstimate(double distance_km, double duration_hours, double avg_consumption_l_100km, double fuel_needed_liters);


    public class GeminiReservationInfo
    {
        public static async Task<TripEstimate> EstimateAsync(string apiKey, string origin, string destination, string carName)
        {
            var model = "gemini-1.5-pro"; // hızlı istersen: gemini-1.5-flash
            var url = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";

            var prompt = $@"
Türkiye içi kara yolu için yaklaşık mesafe ve sürüş süresi tahmini yap.
Araç: {carName}. Mantıklı bir ortalama tüketim (L/100km) varsay.
SADECE şu JSON çıktısını ver (başka metin yok):
{{
  ""distance_km"": <sayı>,
  ""duration_hours"": <sayı>,
  ""avg_consumption_l_100km"": <sayı>,
  ""fuel_needed_liters"": <sayı>
}}
Başlangıç: {origin}
Varış: {destination}";

            var payload = new
            {
                contents = new[] { new { role = "user", parts = new[] { new { text = prompt } } } },
                generationConfig = new { maxOutputTokens = 200, temperature = 0.3 }
            };

            using var http = new HttpClient();
            var res = await http.PostAsync(url,
                new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var body = await res.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(body);

                if (doc.RootElement.TryGetProperty("candidates", out var cands) &&
                    cands.ValueKind == JsonValueKind.Array && cands.GetArrayLength() > 0)
                {
                    var txt = cands[0]
                        .GetProperty("content")
                        .GetProperty("parts")[0]
                        .GetProperty("text")
                        .GetString();

                    // --- JSON'u güvenle ayıkla ---
                    var cleaned = ExtractJsonBlock(txt);

                    using var jd = JsonDocument.Parse(cleaned);
                    var r = jd.RootElement;

                    var dkm = GetDouble(r, "distance_km");
                    var hrs = GetDouble(r, "duration_hours");
                    var l100 = GetDouble(r, "avg_consumption_l_100km");
                    var fuel = GetDouble(r, "fuel_needed_liters");

                    if (dkm > 0 && hrs > 0)
                        return new TripEstimate(dkm, hrs, l100, fuel);
                }
            }
            catch
            {
                // yut ve fallback'e düş
            }

            // Basit fallback (Ankara–İstanbul ~480 km, ~6 s, ~7 L/100km)
            return new TripEstimate(480, 6.0, 7.0, 33.6);
        }

        // ```json ... ``` veya karışık metinden sadece { ... } bölümünü çıkarır
        private static string ExtractJsonBlock(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "{}";
            var t = s.Trim();

            // code fence temizle
            if (t.StartsWith("```"))
            {
                t = t.Replace("```json", "", StringComparison.OrdinalIgnoreCase)
                     .Replace("```", "")
                     .Trim();
            }

            // dıştaki { ... } bloğunu bul
            var a = t.IndexOf('{');
            var b = t.LastIndexOf('}');
            if (a >= 0 && b > a) t = t.Substring(a, b - a + 1);

            // olası arta kalan backtick & boşlukları temizle
            t = t.Trim().Trim('`').Trim();
            return t;
        }

        private static double GetDouble(JsonElement root, string name)
        {
            if (root.TryGetProperty(name, out var el))
            {
                if (el.ValueKind == JsonValueKind.Number)
                    return el.GetDouble();
                if (el.ValueKind == JsonValueKind.String &&
                    double.TryParse(el.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var d))
                    return d;
            }
            return 0;
        }
    }
}
