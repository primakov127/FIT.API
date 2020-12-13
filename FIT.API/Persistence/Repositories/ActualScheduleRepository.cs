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
    public class ActualScheduleRepository : BaseRepository, IActualScheduleRepository
    {
        public ActualScheduleRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IEnumerable<ViewActualSchedule>> FindStudentByDate(DateTime date, string userId)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetStudentActualSchedule", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@studentId", userId));
                    cmd.Parameters.Add(new SqlParameter("@date", date));
                    var result = new List<ViewActualSchedule>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new ViewActualSchedule
                            {
                                ActualScheduleId = (long)reader["Id"],
                                LessonTime = (TimeSpan)reader["Time"],
                                SubjectName = (string)reader["Name"],
                                RoomNum = (int)reader["RoomNum"],
                                HullNum = (int)reader["HullNum"]
                            });
                        }
                    }

                    return result;
                }
            }
        }

        public async Task<IEnumerable<ViewActualSchedule>> FindTeacherByDate(DateTime date, string userId)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetTeacherActualSchedule", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@teacherId", userId));
                    cmd.Parameters.Add(new SqlParameter("@date", date));
                    var result = new List<ViewActualSchedule>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new ViewActualSchedule
                            {
                                ActualScheduleId = (long)reader["Id"],
                                LessonTime = (TimeSpan)reader["Time"],
                                SubjectName = (string)reader["Name"],
                                RoomNum = (int)reader["RoomNum"],
                                HullNum = (int)reader["HullNum"]
                            });
                        }
                    }

                    return result;
                }
            }
        }
    }
}
