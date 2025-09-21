using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class StatusModel : PageModel
    {
        [BindProperty]
        public string Status { get; set; }

        public List<Trainee> Trainee = new List<Trainee>();

        ITrainee tRepo = new ADOTrainee();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Status))
            {
                Trainee = tRepo.GetAllTraineesByStatus(Status);
            }
        }
    }
}
