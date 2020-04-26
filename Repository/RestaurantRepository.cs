using RestaurantWork.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantWork.Repository
{
    public class RestaurantRepository : IREstaurantRepository
    {
        private readonly string  ConnectionString;
        public RestaurantRepository()
        {
            ConnectionString = Properties.Resources.connection;
        }

        public Restaurant GetByName(string name)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "select * from schedule where name = @name";
                SqlCommand command = new SqlCommand(null, con);
                command.CommandText = query;
                SqlParameter nameParameter = new SqlParameter("@name", SqlDbType.VarChar, 100);
                nameParameter.Value = name;
                command.Parameters.Add(nameParameter);
                Restaurant rest = null;
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rest = new Restaurant();
                        rest.Name = (string)reader["name"];
                        rest.Start = Convert.ToDateTime(((TimeSpan)reader["startTime"]).ToString());
                        rest.End = Convert.ToDateTime(((TimeSpan)reader["endTime"]).ToString());
                    }
                }
                return rest;
            }
        }

        public List<String> GetNamesInTime(DateTime time)
        {
            List<string> names = new List<string>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "select name from schedule where startTime <= @time and endTime >= @time";
                SqlCommand command = new SqlCommand(null, con);
                command.CommandText = query;
                SqlParameter nameParameter = new SqlParameter("@time", SqlDbType.VarChar, 100);
                nameParameter.Value = time.ToString("HH:mm:ss");
                command.Parameters.Add(nameParameter);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add((string)reader["name"]);
                    }
                }
            }
            return names;
        }

        public void Update(Restaurant restaurant)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
               
                SqlCommand command = new SqlCommand(null, con);
                command.CommandText = "update schedule set endTime = @end, startTime = @start where name = @name";
                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                SqlParameter startParam = new SqlParameter("@start", SqlDbType.VarChar, 0);
                SqlParameter endParam = new SqlParameter("@end", SqlDbType.VarChar, 0);
                nameParam.Value = restaurant.Name;
                startParam.Value = restaurant.Start.ToString("HH:mm:ss");
                endParam.Value = restaurant.End.ToString("HH:mm:ss");
                command.Parameters.Add(nameParam);
                command.Parameters.Add(startParam);
                command.Parameters.Add(endParam);
                if (command.Connection != null && command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void SaveOne(Restaurant restaurant)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(null, con);
                command.CommandText = "insert into schedule(name, startTime, endTime) values (@name, @start, @end)";
                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                SqlParameter startParam = new SqlParameter("@start", SqlDbType.VarChar, 0);
                SqlParameter endParam = new SqlParameter("@end", SqlDbType.VarChar, 0);
                nameParam.Value = restaurant.Name;
                startParam.Value = restaurant.Start.ToString("HH:mm:ss");
                endParam.Value = restaurant.End.ToString("HH:mm:ss");
                command.Parameters.Add(nameParam);
                command.Parameters.Add(startParam);
                command.Parameters.Add(endParam);
                if (command.Connection != null && command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
