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
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        public ScheduleRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("GetSchedules", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var result = new List<Schedule>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new Schedule
                            {
                                Id = (long)reader["Id"],
                                Week = reader["Week"] == DBNull.Value ? 0 : (int)reader["Week"],
                                SubjectId = (int)reader["SubjectId"],
                                TeacherId = (string)reader["TeacherId"],
                                RoomId = (int)reader["RoomId"],
                                ActualGroupId = (int)reader["ActualGroupId"],
                                SubGroupId = (int)reader["SubGroupId"],
                                WeekDayId = (int)reader["WeekDayId"],
                                LessonNumId = (int)reader["LessonNumId"]
                            });
                        }
                    }

                    return result;
                }
            }
        }
    }
}
