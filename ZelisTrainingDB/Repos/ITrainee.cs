using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public interface ITrainee
    {
        void NewTrainee(Trainee trainee);

        void UpdateTrainee(int id,Trainee trainee);   

        void DeleteTrainee(int id);
        List<Trainee> GetAll();
        Trainee GetTraineeById(int id); 
        List<Training> GetAllTrainingsByTrainee(int id);
        List<Trainee> GetAllTraineesByStatus(string status);
        Employee GetTrainerDetails(int id); 
    }
}
