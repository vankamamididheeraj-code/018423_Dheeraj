using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public interface ITechnology
    {
        void NewTechnology(Technology technology);  
        void UpdateTechnology(int id,Technology technology);

        void DeleteTechnology(int id);
        List<Technology> GetAll();
        Technology GetTechnologyById(int id);

        List<Technology> GetTechnologyByLevel(string level); 
         
    }
}
