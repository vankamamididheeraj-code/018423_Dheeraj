using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace TrainerWebApp.Pages.Trainers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer { get; set; }
        ITrainer trainRepo = new ADOTrainer();
        static int trainid;
        public void OnGet(int trid)
        {
            trainid = trid;
            Trainer = trainRepo.GetTrainerById(trid);
        }
        public IActionResult OnPost()
        {
            trainRepo.UpdateTrainer(trainid,Trainer);
            return RedirectToPage("/Trainers/Index");

        }
    }
}
