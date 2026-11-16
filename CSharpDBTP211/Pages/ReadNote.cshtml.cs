using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpDBTP211.Pages;

public class ReadNoteModel : PageModel
{
    private readonly IWebHostEnvironment _environment;

    public ReadNoteModel(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public List<string> FileNames { get; set; } = new();

    public string? Content { get; set; }

    public string? SelectedFileName { get; set; }

    public void OnGet()
    {
        LoadFileNames();
    }

    public IActionResult OnGetView(string fileName)
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

        Content = System.IO.File.ReadAllText(filePath);
        SelectedFileName = fileName;

        LoadFileNames();

        return Page();
    }

    private void LoadFileNames()
    {
        string directory = Path.Combine(_environment.WebRootPath, "files");

        if (Directory.Exists(directory))
        {
            FileNames = Directory.GetFiles(directory, "note-*.txt")
                .Select(Path.GetFileName)
                .Where(name => name != null)
                .ToList()!;
        }
    }
}