using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DetailsModel : PageModel
    {
        public Trainee trainee = new Trainee();
        public Trainee Trainee { get; set; }
        ITrainee tRepo = new ADOTrainee();
        public void OnGet(int tid)
        {
            Trainee = tRepo.GetTraineeById(tid);
        }
    }
}
