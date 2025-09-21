using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ZelisTrainingDB.Models;

namespace ZelisTrainingDB.Repos
{
    public class ADOTechnology : ITechnology
    {
        SqlConnection con;
        SqlCommand cmd;

        public  ADOTechnology()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source = (localdb)\MSSQLLocalDB; database = ZelisTrainingDB; integrated security = true";
            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        public void NewTechnology(Technology technology)
        {
            cmd.CommandText = $"insert into Technology values({technology.TechnologyId},'{technology.TechName}','{technology.TechLevel}',{technology.Duration})";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTechnology(int id, Technology technology)
        {
            cmd.CommandText = $"update Technology set TechName = '{technology.TechName}',TechLevel = '{technology.TechLevel}', Duration = {technology.Duration} where TechnologyId = {technology.TechnologyId}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTechnology(int id)
        {
            cmd.CommandText = $"delete from Technology where TechnologyId ={id}";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Technology> GetAll()
        {
            cmd.CommandText = $"Select * from Technology";
            con.Open();
            List<Technology> technology = new List<Technology>();
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("List of All Technologies....");
            while (reader.Read())
            {
                Technology item = new Technology(); 
                item.TechnologyId=(int)(reader["Technologyid"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (string)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                technology.Add(item);
            }
            con.Close();
            return technology;
        }

        public Technology GetTechnologyById(int id)
        {
            cmd.CommandText = $"select * from Technology where TechnologyId ={id}";
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["Technologyid"]);
                item.TechName = (string)(reader["TechName"]);
                item.TechLevel = (string)(reader["TechLevel"]);
                item.Duration = (int)(reader["Duration"]);
                con.Close();
                return item;    
            }
            else
            {
                con.Close ();
                throw new TrainingException("Technology Not Found");
            }
        }

        public List<Technology> GetTechnologyByLevel(string level)
        {
            cmd.CommandText = $"select * from Technology where TechLevel ={level}";
            con.Open();
            List<Technology> technologies = new List<Technology>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Technology item = new Technology();
                item.TechnologyId = (int)(reader["Technologyid"]);
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
