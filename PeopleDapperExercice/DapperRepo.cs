using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.VisualBasic;
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

        public Person GetbyId(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM People WHERE Id = @Id";
                Person person = connection.QuerySingleOrDefault<Person>(sql, new { Id = id });

                if (person == null)
                {
                    throw new Exception($"Aucune personne trouvée avec l'id {id}");
                }
                
                return person;
            }
        }

        public IEnumerable<Person> GetAll()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM People ORDER BY Name";
                return connection.Query<Person>(sql);
            }
        
        }

        public void UpdatePerson(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE People SET Name = @Name, Age = @Age Where Id = @Id";
                connection.Execute(sql, person);
            }
        }

        public void DeletePerson(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM People WHERE Id = @Id";
                connection.Execute(sql, new { Id = id});
            }
        }
    }
}