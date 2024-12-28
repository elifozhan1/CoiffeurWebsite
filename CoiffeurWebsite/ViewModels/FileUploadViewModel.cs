using Microsoft.AspNetCore.Http;

public class FileUploadViewModel
{
    public IFormFile File { get; set; } // Kullanıcıdan dosya alımı için
    public string Style { get; set; } // Kullanıcının seçtiği stil
    public string ProcessedResult { get; set; } // API sonucunu tutmak için
}