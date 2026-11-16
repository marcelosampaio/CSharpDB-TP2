using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpDBTP212.Pages;

public class SaveNoteModel : PageModel
{
    public class InputModel
    {
        public string Content { get; set; } = string.Empty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? FileName { get; set; }

    private readonly IWebHostEnvironment _environment;

    public SaveNoteModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public void OnPost()
    {
        string directory = Path.Combine(_environment.WebRootPath, "files");

        Directory.CreateDirectory(directory);

        FileName = $"note-{DateTime.Now:yyyyMMddHHmmssfff}.txt";

        string filePath = Path.Combine(directory, FileName);

        System.IO.File.WriteAllText(filePath, Input.Content);
    }

    public IActionResult OnGetDownload(string fileName)
    {
        if (Path.GetFileName(fileName) != fileName ||
            !fileName.StartsWith("note-") ||
            !fileName.EndsWith(".txt"))
        {
            return BadRequest();
        }
        
        string directory = Path.Combine(_environment.WebRootPath, "files");
        string filePath = Path.Combine(directory, fileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        return PhysicalFile(filePath, "text/plain", fileName);
    }
}