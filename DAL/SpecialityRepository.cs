using Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace DAL
{
    public class SpecialityRepository : ISpecialityRepository
    {
        public async Task<Speciality> GetByIdAsync(int specialityId)
        {
            var speciality = new Speciality();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM speciality");
            sql.AppendLine("WHERE Id = @specialityId");

            await using (var connection = new MySqlConnection(Config.DbConnectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand(sql.ToString(), connection);
                command.Parameters.AddWithValue("specialityId", specialityId);

                var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    speciality = PopulateSpeciality(reader);
                }
            }

            return speciality;
        }

        public async Task<List<Speciality>> ListAllAsync()
        {
            var specialityList = new List<Speciality>();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM speciality");

            await using (var connection = new MySqlConnection(Config.DbConnectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand(sql.ToString(), connection);

                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    specialityList.Add(PopulateSpeciality(reader));
                }
            }

            return specialityList;
        }

        public async Task SaveAsync(Speciality speciality)
        {
            var sql = new StringBuilder();
            sql.AppendLine("UPDATE speciality SET");
            sql.AppendLine("SpecialityName = @specialityName,");
            sql.AppendLine("WHERE Id = @specialityId");

            await using (var connection = new MySqlConnection(Config.DbConnectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand(sql.ToString(), connection);
                command.Parameters.AddWithValue("specialityName", speciality.SpecialityName);
                command.Parameters.AddWithValue("specialityId", speciality.Id);

                await command.ExecuteNonQueryAsync();
            }
        }

        private Speciality PopulateSpeciality(IDataRecord data)
        {
            var speciality = new Speciality
            {
                Id = int.Parse(data["Id"].ToString()),
                SpecialityName = data["SpecialityName"].ToString(),
            };
            return speciality;
        }
    }
}
