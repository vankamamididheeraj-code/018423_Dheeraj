using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingDB.Models;
namespace ZelisTrainingDB.Repos
{
    public class ADOTrainer : ITrainer
    {
        SqlConnection con;
        SqlCommand cmd; 
        public ADOTrainer()
        {
        con = new SqlConnection();
        con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
        cmd = new SqlCommand();
        cmd.Connection = con;
        }

        public void NewTrainer(Trainer trainer)
        {
            cmd.CommandText = $"insert into Trainer values({trainer.TrainerId},'{trainer.TrainerName}','{trainer.TrainerType}','{trainer.Email}','{trainer.Phone}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTrainer(int id,Trainer trainer)
        {
            cmd.CommandText = $"update Trainer set TrainerName = '{trainer.TrainerName}',TrainerType = '{trainer.TrainerType}', Email = '{trainer.Email}', Phone='{trainer.Phone}' where TrainerId = {trainer.TrainerId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteTrainer(int id)
        { 
            cmd.CommandText = $"delete from Trainer where TrainerId ={id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Trainer> GetAll()
        {
            cmd.CommandText = $"Select * from Trainer";
            con.Open();
            List<Trainer> trainer = new List<Trainer>();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("List of All Trainers....");
            while (reader.Read())
            {
                Trainer item = new Trainer();
                item.TrainerId = (int)(reader["Trainerid"]);
                item.TrainerName = (string)(reader["TrainerName"]);
                item.TrainerType = (string)(reader["TrainerType"]);
                item.Email = (string)(reader["Email"]);
                item.Phone = (string)(reader["Phone"]);
                trainer.Add(item);
            }
            con.Close();
            return trainer;
        }

        public Trainer GetTrainerById(int id)
        {
            cmd.CommandText = $"select * from Trainer where TrainerId={id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Trainer item = new Trainer();
                item.TrainerId = (int)(reader["Trainerid"]);
                item.TrainerName = (string)(reader["TrainerName"]);
                item.TrainerType = (string)(reader["TrainerType"]);
                item.Email = (string)(reader["Email"]);
                item.Phone = (string)(reader["Phone"]);
                con.Close();
                return item;
            }
            else
            {
                con.Close();
                throw new TrainingException("Trainer Not Found");
            }
        }

        public List<Trainer> GetTrainersByType(string type)
        {
            cmd.CommandText = $"select * from Trainer where TrainerType = '{type}'";
            con.Open();
            List<Trainer> trainers = new List<Trainer>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainer trainer = new Trainer();
                trainer.TrainerId = (int)(reader["TrainerId"]);
                trainer.TrainerName = (string)(reader["Name"]);
                trainer.TrainerType = (string)(reader["Type"]);
                trainer.Email = (string)(reader["Email"]);
                trainer.Phone = (string)(reader["Phone"]);
                trainers.Add(trainer);
            }
            con.Close();
            return trainers;
        }

    }
}
