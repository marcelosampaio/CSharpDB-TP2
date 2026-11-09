using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpDBTP206.Models;

namespace CSharpDBTP206.Pages.CountryManager;

public class CreateCountryModel : PageModel
{
    public class InputModel
    {
        public string CountryName { get; set; } = string.Empty;

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string CountryCode { get; set; } = string.Empty;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public Country? Country { get; set; }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            Country = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };
        }
    }
}