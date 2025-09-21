using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace TrainerWebApp.Pages.Trainers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Trainer Trainer {  get; set; }
        ITrainer trainRepo = new ADOTrainer();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            trainRepo.NewTrainer(Trainer);
            return RedirectToPage("/Trainers/Index");
        }
    }
}
