using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace TrainingWebApp.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        public List<Training> training = new List<Training>();
        ITraining trainingRepo=new ADOTraining();
       public void OnGet()
        {
            training = trainingRepo.GetAll();
        }
    }
}
