using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace TrainingWebApp.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
        public Training Training { get; set; }
        ITraining trainingRepo = new ADOTraining();
        static int trainingid;
        public void OnGet(int tiid)
        {
            trainingid = tiid;
            Training = trainingRepo.GetTrainingById(tiid);
        }
        public IActionResult OnPost()
        {
            trainingRepo.DeleteTraining(trainingid);
            return RedirectToPage("/Trainings/Index");

        }
    }
}
