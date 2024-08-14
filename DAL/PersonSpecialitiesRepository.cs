using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonSpecialitiesRepository : IPersonSpecialitiesRepository
    {
        public async Task<List<PersonSpecialities>> ListForPersonIdAsync(int personId)
        {
            var personSpecialities = new List<PersonSpecialities>();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM PersonSpecialities");
            sql.AppendLine("WHERE PersonId = @personId");

            await using (var connection = new MySqlConnection(Config.DbConnectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand(sql.ToString(), connection);
                command.Parameters.AddWithValue("personId", personId);

                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    personSpecialities.Add(PopulatePersonSpecialities(reader));
                }
            }

            return personSpecialities;
        }

        public async Task SaveAsync(PersonSpecialities personSpecialities)
        {
            var sql = new StringBuilder();
            sql.AppendLine("UPDATE PersonSpecialities SET");
            sql.AppendLine("PersonId = @personId,");
            sql.AppendLine("SpecialityId = @specialityId,");
            sql.AppendLine("WHERE Id = @id");

            await using (var connection = new MySqlConnection(Config.DbConnectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand(sql.ToString(), connection);
                command.Parameters.AddWithValue("personId", personSpecialities.PersonId);
                command.Parameters.AddWithValue("lastName", personSpecialities.SpecialityId);
                command.Parameters.AddWithValue("personId", personSpecialities.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        private PersonSpecialities PopulatePersonSpecialities(IDataRecord data)
        {
            var personSpecialities = new PersonSpecialities
            {
                Id = int.Parse(data["Id"].ToString()),
                PersonId = int.Parse(data["PersonId"].ToString()),
                SpecialityId = int.Parse(data["SpecialityId"].ToString()),
            };
            return personSpecialities;
        }
    }
}
