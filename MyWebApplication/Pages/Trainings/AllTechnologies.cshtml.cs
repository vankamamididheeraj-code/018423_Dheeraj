using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace MyWebApplication.Pages.Trainings
{
    public class AllTechnologiesModel : PageModel
    {
        [BindProperty]
        public int TrainerIdInput { get; set; }

        public List<Technology> Technology { get; set; } = new List<Technology>();

        ITraining trainingRepo = new ADOTraining();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (TrainerIdInput > 0)
            {
                Technology = trainingRepo.GetAlltechnologiesByTrainer(TrainerIdInput);
            }
        }
    }
}
