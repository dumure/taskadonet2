using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace task_ado_2
{
    internal class CarsDB
    {
        private List<Car> _cars;
        public CarsDB()
        {
            _cars = new List<Car>();
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new(
                    @"USE CarsDB
                      SELECT * FROM Cars"
                    , connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _cars.Add(new Car() { Mark = (string)reader["Mark"], Model = (string)reader["Model"] });
                }
            }
        }
        public List<Car> GetCars()
        {
            return _cars;
        }
        public void AddCar(Car car)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Library;Integrated Security=SSPI;";
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new(
                    @$"USE [UsersDB]
                      GO
                      INSERT INTO Users(Mark, Model)
                      VALUES(@mark, @model)"
                    , connection);
                cmd.Parameters.Add("@mark", System.Data.SqlDbType.NVarChar, 32).Value = car.Mark;
                cmd.Parameters.Add("@model", System.Data.SqlDbType.NVarChar, 32).Value = car.Model;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
