using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace TrainerWebApp.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        int trainid;
        public Trainer Trainer { get; set; }
        ITrainer trainRepo = new ADOTrainer();
        public void OnGet(int trid)
        {
            Trainer = trainRepo.GetTrainerById(trid);
        }
        public IActionResult OnPost()
        {
            trainRepo.DeleteTrainer(trainid);
            return RedirectToPage("/Trainers/Index");

        }
    }
}
