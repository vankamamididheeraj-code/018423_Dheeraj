using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace MyWebApplication.Pages.Trainings
{
    public class AllTrainingsModel : PageModel
    {
        [BindProperty]
        public int TrainerIdInput { get; set; }

        public List<Training> Trainings { get; set; } = new List<Training>();

        ITraining trainingRepo = new ADOTraining();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (TrainerIdInput > 0)
            {
                Trainings = trainingRepo.GetAlltechnologiesInTraining(TrainerIdInput);
            }
        }
    }
}

