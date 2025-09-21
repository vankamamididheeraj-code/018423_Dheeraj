using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary;
using ZelisTrainingLibrary.Repos;
namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class IndexModel : PageModel
    {
        public List<Trainee> trainee = new List<Trainee>();
        public Trainee Trainee { get; set; }
        ITrainee tRepo = new ADOTrainee();
        public void OnGet()
        {
            trainee = tRepo.GetAll();
        }
    }
}
