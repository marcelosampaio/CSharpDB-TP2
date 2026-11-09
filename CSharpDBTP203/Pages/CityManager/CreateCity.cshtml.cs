using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpDBTP204.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public class InputModel
    {
        [Required]
        [MinLength(3)]
        public string CityName { get; set; } = string.Empty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            return;
        }
    }
}