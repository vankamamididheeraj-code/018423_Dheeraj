using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace Technologies.Pages.Technologys
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Technology Technology { get; set; }
        ITechnology techRepo = new ADOTechnology();
        static int techid;
        public void OnGet(int tid)
        {
            techid = tid;
           Technology = techRepo.GetTechnologyById(tid);   
        }
        public IActionResult OnPost()
        {
            techRepo.UpdateTechnology(techid, Technology);
            return RedirectToPage("/Technologys/Index");

        }
    }
}
