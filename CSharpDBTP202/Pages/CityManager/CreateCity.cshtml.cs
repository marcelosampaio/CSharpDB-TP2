using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpDBTP202.Pages.CityManager;

public class CreateCityModel : PageModel
{
    public string CityName { get; set; } = string.Empty;

    public void OnPost(string cityName)
    {
        CityName = cityName;
    }
}