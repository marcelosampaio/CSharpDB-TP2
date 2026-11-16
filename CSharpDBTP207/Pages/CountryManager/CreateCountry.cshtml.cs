using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpDBTP207.Models;

namespace CSharpDBTP207.Pages.CountryManager;

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
    public List<InputModel> Countries { get; set; } = new()
    {
        new InputModel(),
        new InputModel(),
        new InputModel(),
        new InputModel(),
        new InputModel()
    };

    public List<Country> CreatedCountries { get; set; } = new();

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            CreatedCountries = Countries.Select(input => new Country
            {
                CountryName = input.CountryName,
                CountryCode = input.CountryCode
            }).ToList();
        }
    }
}