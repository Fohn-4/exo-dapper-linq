using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace PeopleDapperExercice
{
    public class DapperRepo
    {
        private readonly string _connectionString;
        public DapperRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO People (Name, Age) VALUES (@Name, @Age)";
                connection.Execute(sql, person);
            }
        }
    }
}