using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainee Trainee { get; set; }
        ITrainee trainee = new ADOTrainee();
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            trainee.NewTrainee(Trainee);
            return RedirectToPage("/Trainees/Index");

        }
    }
}
