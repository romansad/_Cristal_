using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MUNICIPALIDAD_V4.Data
{
    public class ValuesRepository
    {
        private readonly string _connectionString;
        public ValuesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<int> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GENERACION_INTERESES", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new int();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Value MapToValue(SqlDataReader reader)
        {
            return new Value()
            {
                Id = (int)reader["Id"],
                Value1 = (int)reader["Value1"],
                Value2 = reader["Value2"].ToString()
            };
        }

        public Task GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Value value)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
