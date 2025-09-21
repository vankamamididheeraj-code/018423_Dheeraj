using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZelisTrainingDB;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;
using Microsoft.Data.SqlClient;
namespace Technologies.Pages.Technologys
{
    public class IndexModel : PageModel
    {
        public List<Technology> tech = new List<Technology>();
        ITechnology techRepo = new ADOTechnology();
        public void OnGet()
        {
            tech=techRepo.GetAll();
        }
    }
}
