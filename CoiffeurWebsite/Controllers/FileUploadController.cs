using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

public class FileUploadController : Controller
{
    private readonly HairstyleChangerService _hairstyleChangerService;

    public FileUploadController(HairstyleChangerService hairstyleChangerService)
    {
        _hairstyleChangerService = hairstyleChangerService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(); // Kullanıcıdan dosya yükleme isteği için form gösterecek
    }

    [HttpPost]
    public async Task<IActionResult> Index(FileUploadViewModel model)
    {
        if (model.File == null || model.File.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Please upload a file.");
            return View(model);
        }

        try
        {
            // Binary dosyayı okumak için Stream oluştur
            using var imageStream = model.File.OpenReadStream();

            // API'yi çağır ve sonucu al
            var result = await _hairstyleChangerService.ChangeHairstyleAsync(imageStream, model.Style);

            // Base64 string'i uygun formatta model'e gönder
            model.ProcessedResult = $"data:image/jpeg;base64,{result}";
            return View(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            return View(model);
        }
    }

}
