using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using Microsoft.Data.SqlClient;
namespace TrainerWebApp.Pages.Trainers
{
    public class IndexModel : PageModel
    {
        public List<Trainer> train=new List<Trainer>();
        ITrainer trainRepo = new ADOTrainer();
        public void OnGet()
        {
            train = trainRepo.GetAll();
        }
    }
}
