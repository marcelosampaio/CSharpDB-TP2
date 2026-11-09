using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpDBTP205.Models;

namespace CSharpDBTP205.Pages.CountryManager;

public class CreateCountryModel : PageModel
{
    public class InputModel
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public Country? Country { get; set; }

    public void OnPost()
    {
        Country = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };
    }
}