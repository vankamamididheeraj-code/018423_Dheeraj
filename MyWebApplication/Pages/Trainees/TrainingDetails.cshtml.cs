using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace MyWebApplication.Pages.Trainees
{
    public class TrainingDetailsModel : PageModel
    {
        public Training Training { get; set; }
        ITraining tRepo = new ADOTraining();
        public void OnGet(int tid)
        {
            Training = tRepo.GetTrainingById(tid);
        }
    }
}
