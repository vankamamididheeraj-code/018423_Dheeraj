using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public interface ITrainer
    {
        void NewTrainer(Trainer traineer);

        void UpdateTrainer(int id,Trainer trainer);   

        void DeleteTrainer(int id);   

        List<Trainer> GetAll();    

        Trainer GetTrainerById(int id);

        List<Trainer> GetTrainersByType(string  type);    


    }
}
