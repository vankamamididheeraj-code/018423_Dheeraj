using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
namespace Technologies.Pages.Technologys
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }
        ITechnology techRepo = new ADOTechnology();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            techRepo.NewTechnology(Technology);
            return RedirectToPage("/Technologys/Index");
        }
    }
}
