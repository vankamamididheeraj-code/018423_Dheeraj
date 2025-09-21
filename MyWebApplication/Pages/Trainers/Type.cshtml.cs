using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace MyWebApplication.Pages.Trainers
{
    public class TypeModel : PageModel
    {
            [BindProperty]
            public string Type { get; set; }

        public List<Trainer> Trainer = new List<Trainer>();

        ITrainer tRepo = new ADOTrainer();

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Type))
            {
                Trainer = tRepo.GetTrainersByType(Type);
            }
        }
    }
}

