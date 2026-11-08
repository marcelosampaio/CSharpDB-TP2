using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpDBTP201.Pages.CityManager;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public string CityName { get; set; } = string.Empty;

    public void OnPost()
    {
    }
}