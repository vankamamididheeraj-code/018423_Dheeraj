using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;


namespace TrainingWebApp.Pages.Trainings
{
    public class EditModel : PageModel
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
            trainingRepo.UpdateTraining(trainingid, Training);
            return RedirectToPage("/Trainings/Index");

        }
    }
}
