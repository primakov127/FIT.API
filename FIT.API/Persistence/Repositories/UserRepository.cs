using FIT.API.Domain.Models;
using FIT.API.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task AddUserStudentAsync(SaveUser user)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("AddUserStudent", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@firstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@middleName", user.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@group", user.Group));
                    cmd.Parameters.Add(new SqlParameter("@subGroup", user.SubGroup));
                    cmd.Parameters.Add(new SqlParameter("@course", user.Course));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task AddUserTeacherAsync(SaveUser user)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("AddUserTeacher", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@firstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@middleName", user.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", user.LastName));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
