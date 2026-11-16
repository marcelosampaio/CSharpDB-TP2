using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CSharpDBTP212.Models;

namespace CSharpDBTP212.Pages.CountryManager;

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
        for (int i = 0; i < Countries.Count; i++)
        {
            string countryName = Countries[i].CountryName;
            string countryCode = Countries[i].CountryCode;

            if (!string.IsNullOrWhiteSpace(countryName) &&
                !string.IsNullOrWhiteSpace(countryCode) &&
                !countryName.StartsWith(
                    countryCode.Substring(0, 1),
                    StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(
                    $"Countries[{i}].CountryCode",
                    "Country name and code must start with the same letter.");
            }
        }

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