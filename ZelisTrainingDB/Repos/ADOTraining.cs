using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTraining : ITraining
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTraining()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void NewTraining(Training training)
        {
            cmd.CommandText = cmd.CommandText = $"insert into Training values({training.TrainingId},{training.TrainerId},{training.TechnologyId},'{training.StartDate}', '{training.EndDate}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTraining(int id, Training training)
        {
            cmd.CommandText = $"update Training set TrainerId = {training.TrainerId}, StartDate = '{training.StartDate}', EndDate = '{training.EndDate}' where TrainingId = {training.TrainingId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void DeleteTraining(int id)
        {
            cmd.CommandText = $"delete from Training where = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<Training> GetAll()
        {
            cmd.CommandText = $"select * from Training";
            con.Open();
            List<Training> training = new List<Training>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training item = new Training();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.TrainerId = (int)(reader["TrainerId"]);
                item.StartDate = (DateTime)reader["StartDate"];
                item.EndDate = (DateTime)reader["EndDate"];
                training.Add(item);
            }
            con.Close();
            return training;
        }
        public Training GetTrainingById(int id)
        {
            cmd.CommandText = $"select * from Training where TrainingId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Training item = new Training();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.TrainerId = (int)(reader["TrainerId"]);
                item.StartDate = (DateTime)reader["StartDate"];
                item.EndDate = (DateTime)reader["EndDate"];
                con.Close();
                return item;
            }
            else
            {
                con.Close();
                throw new TrainingException("Training Not Found ");
            }

        }

        public List<Training> GetAlltechnologiesInTraining(int id)
        {
            cmd.CommandText = $"select * from Tarining where TrainingId = {id}";
            con.Open();
            List<Training> training = new List<Training>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Training item = new Training();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.TrainerId = (int)(reader["TrainerId"]);
                item.StartDate = (DateTime)reader["StartDate"];
                item.EndDate = (DateTime)reader["EndDate"];
                training.Add(item);
            }
            con.Close();
            return training;
        }

        public List<Technology> GetAlltechnologiesByTrainer(int id)
        {
            cmd.CommandText = $"select * from Technology where TechnologyId = {id}";
            con.Open();
            List<Technology> technologies = new List<Technology>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["TechnologyId"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (string)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                technologies.Add(item);

            }
            con.Close();
            return technologies;
        }
    }
}

