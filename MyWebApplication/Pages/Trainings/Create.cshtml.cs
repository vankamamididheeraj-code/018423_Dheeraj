using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace TrainingWebApp.Pages.Trainings
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Training Training { get; set; }
        ITraining trainingRepo = new ADOTraining();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            trainingRepo.NewTraining(Training);
            return RedirectToPage("/Trainings/Index");
        }
    }
}
