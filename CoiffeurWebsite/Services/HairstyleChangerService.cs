using System;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class HairstyleChangerService
{
    private const string ApiBaseUrl = "https://hairstyle-changer.p.rapidapi.com/huoshan/facebody/hairstyle";
    private const string ApiKey = "07b4e60c59msh2516b0812bae1f8p14575fjsn31c3f08f87ab";
    private const string ApiHost = "hairstyle-changer.p.rapidapi.com";

    private readonly HttpClient _httpClient;

    public HairstyleChangerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ChangeHairstyleAsync(Stream imageStream, string style)
    {
        try
        {
            Console.WriteLine("API çağrısı başlıyor...");

            // Multipart/form-data isteği için content oluştur
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(imageStream), "image_target", "uploaded_image.jpg"); // Binary dosya içeriği
            content.Add(new StringContent(style), "hair_type"); // Stil verisi

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(ApiBaseUrl),
                Headers =
            {
                { "x-rapidapi-key", ApiKey },
                { "x-rapidapi-host", ApiHost },
            },
                Content = content
            };

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            using var response = await _httpClient.SendAsync(request);
            stopwatch.Stop();
            Console.WriteLine($"Yanıt süresi: {stopwatch.ElapsedMilliseconds} ms");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API çağrısı başarılı.");
                return result;
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API hatası: {errorContent}");
            throw new HttpRequestException($"API çağrısı başarısız oldu: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
            throw;
        }

    }

}