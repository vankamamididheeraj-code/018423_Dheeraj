using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using ZelisTrainingLibrary.Repos;

namespace ZelisTrainingRazorWebApp.Pages.Trainees
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Trainee Trainee { get; set; }
        ITrainee trainee = new ADOTrainee();
        static int Tid;
        public void OnGet(int tid)
        {
            Tid = tid;
            Trainee = trainee.GetTraineeById(tid);

        }
        public IActionResult OnPost()
        {
            trainee.DeleteTrainee(Tid);
            return RedirectToPage("/Trainees/Index");

        }
    }
}
