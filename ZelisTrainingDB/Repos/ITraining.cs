
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public interface ITraining
    {
        void NewTraining(Training training);

        void UpdateTraining(int id, Training trainer);

        void DeleteTraining(int id);

        List<Training> GetAll();
        Training GetTrainingById(int id);

        List<Training> GetAlltechnologiesInTraining(int id);

        List<Technology> GetAlltechnologiesByTrainer(int id);
    }
}
