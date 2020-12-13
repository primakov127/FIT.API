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
    public class AttendanceRepository : BaseRepository, IAttendanceRepository
    {
        public AttendanceRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IEnumerable<AllLessonAttendance>> FindAllLessonsAsync(long actualScheduleId)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetSubGroupAllAttendace", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@actualScheduleId", actualScheduleId));
                    var result = new List<AllLessonAttendance>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new AllLessonAttendance
                            {
                                AttendanceId = (long)reader["Id"],
                                UserLastName = (string)reader["LastName"],
                                IsPresent = reader["IsPresent"] == DBNull.Value ? null : (bool)reader["IsPresent"],
                                Mark = reader["Mark"] == DBNull.Value ? null : (int)reader["Mark"],
                                Comment = reader["Comment"] == DBNull.Value ? null : (string)reader["Comment"],
                                Date = (DateTime)reader["Date"]
                            });
                        }
                    }

                    return result;
                }
            }
        }

        public async Task<IEnumerable<OneLessonAttendance>> FindOneLessonAsync(string teacherId, long actualScheduleId)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetTeacherStudentsOneAttendance", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@teacherId", teacherId));
                    cmd.Parameters.Add(new SqlParameter("@actualScheduleId", actualScheduleId));
                    var result = new List<OneLessonAttendance>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new OneLessonAttendance
                            {
                                AttendanceId = (long)reader["Id"],
                                UserFirstName = (string)reader["FirstName"],
                                UserMiddleName = (string)reader["MiddleName"],
                                UserLastName = (string)reader["LastName"],
                                IsPresent = reader["IsPresent"] == DBNull.Value ? null : (bool)reader["IsPresent"],
                                Mark = reader["Mark"] == DBNull.Value ? null : (int)reader["Mark"],
                                Comment = reader["Comment"] == DBNull.Value ? null : (string)reader["Comment"]
                            });
                        }
                    }

                    return result;
                }
            }
        }
    }
}
