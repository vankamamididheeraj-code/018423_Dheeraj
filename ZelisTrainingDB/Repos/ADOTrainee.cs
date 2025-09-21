using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using ZelisTrainingDB.Models;
using ZelisTrainingDB.Repos;

namespace ZelisTrainingLibrary.Repos
{
    public class ADOTrainee : ITrainee
    {
        SqlConnection con;
        SqlCommand cmd;

        public ADOTrainee()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public void NewTrainee(Trainee trainee)
        {
            cmd.CommandText = $"insert into Trainee values({trainee.TrainingId},{trainee.EmpId},'{trainee.Status}')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTrainee(int id, Trainee trainee)
        {
            cmd.CommandText = $"update Trainee set Status = '{trainee.Status}' where TrainingId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteTrainee(int id)
        {
            cmd.CommandText = $"delete from Trainee where TrainerId = {id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public List<Trainee> GetAll()
        {
            cmd.CommandText = $"select * from Trainee";
            con.Open();
            List<Trainee> trainees = new List<Trainee>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Trainee trainee = new Trainee();
                trainee.TrainingId = (int)(reader["TrainingId"]);
                trainee.EmpId = (int)(reader["EmpId"]);
                trainee.Status = (string)(reader["Status"]);
                trainees.Add(trainee);
            }
            con.Close();
            return trainees;
        }
        public Trainee GetTraineeById(int id)
        {
            cmd.CommandText = $"select * from Trainee where TrainingId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Trainee item = new Trainee();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.EmpId = (int)(reader["EmpId"]);
                item.Status = (string)(reader["Status"]);
                con.Close();
                return item;
            }
            else
            {
                con.Close();
                throw new TrainingException("Trainee Not Found ");
            }
        }

        public List<Training> GetAllTrainingsByTrainee(int id)
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
                item.StartDate = (DateTime)(reader["StartDate"]);
                item.EndDate = (DateTime)(reader["EndDate"]);
                training.Add(item);
            }
            con.Close();
            return training;

        }
        public List<Trainee> GetAllTraineesByStatus(string status)
        {
            cmd.CommandText = $"select * from Trainee where Status = '{status}'";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Trainee> trainees = new List<Trainee>();
            while (reader.Read())
            {
                Trainee item = new Trainee();
                item.TrainingId = (int)(reader["TrainingId"]);
                item.EmpId = (int)(reader["EmpId"]);
                item.Status = (string)(reader["Status"]);
                trainees.Add(item);
            }
            con.Close();
            return trainees;
        }
        public Employee GetTrainerDetails(int id)
        {
            cmd.CommandText = $"select * from Employee where EmpId = {id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Employee employee = new Employee();
                employee.EmpId = (int)(reader["EmpId"]);
                employee.EmpName = (string)(reader["EmpName"]);
                employee.EmpDesignation = (string)(reader["Designation"]);
                employee.EmpEmail = (string)(reader["Email"]);
                employee.EmpPhone = (string)(reader["Phone"]);
                con.Close();
                return employee;

            }
            else
            {
                con.Close();
                throw new TrainingException("Trainer Not Found ");
            }
        }

    }
}