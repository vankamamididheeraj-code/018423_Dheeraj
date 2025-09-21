using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace MyWebApplication.Pages.Technologys
{
    public class LevelModel : PageModel
    {
        [BindProperty]
        public string LevelInput { get; set; }

        public List<Technology> Technology { get; set; } = new List<Technology>();

        ITechnology techRepo = new ADOTechnology();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(LevelInput))
            {
                Technology = techRepo.GetTechnologyByLevel(LevelInput);
            }
        }
    }
}

