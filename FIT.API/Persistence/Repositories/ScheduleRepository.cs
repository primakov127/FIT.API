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

        public async Task AddOneInTwoWeekAsync(SaveSchedule saveSchedule)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("AddScheduleOneInTwoWeek", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var outPutId = new SqlParameter("@id", System.Data.SqlDbType.BigInt)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outPutId);
                    cmd.Parameters.Add(new SqlParameter("@subjectId", saveSchedule.SubjectId));
                    cmd.Parameters.Add(new SqlParameter("@teacherId", saveSchedule.TeacherId));
                    cmd.Parameters.Add(new SqlParameter("@roomId", saveSchedule.RoomId));
                    cmd.Parameters.Add(new SqlParameter("@week", saveSchedule.Week));
                    cmd.Parameters.Add(new SqlParameter("@weekDay", saveSchedule.WeekDay));
                    cmd.Parameters.Add(new SqlParameter("@lessonNum", saveSchedule.LessonNum));
                    cmd.Parameters.Add(new SqlParameter("@course", saveSchedule.Course));
                    cmd.Parameters.Add(new SqlParameter("@group", saveSchedule.Group));
                    cmd.Parameters.Add(new SqlParameter("@subGroup", saveSchedule.SubGroup));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    saveSchedule.ScheduleId = (long)outPutId.Value;
                }
            }
        }

        public async Task AddTwoInTwoWeekAsync(SaveSchedule saveSchedule)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("AddScheduleTwoInTwoWeek", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var outPutId = new SqlParameter("@id", System.Data.SqlDbType.BigInt)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outPutId);
                    cmd.Parameters.Add(new SqlParameter("@subjectId", saveSchedule.SubjectId));
                    cmd.Parameters.Add(new SqlParameter("@teacherId", saveSchedule.TeacherId));
                    cmd.Parameters.Add(new SqlParameter("@roomId", saveSchedule.RoomId));
                    cmd.Parameters.Add(new SqlParameter("@weekDay", saveSchedule.WeekDay));
                    cmd.Parameters.Add(new SqlParameter("@lessonNum", saveSchedule.LessonNum));
                    cmd.Parameters.Add(new SqlParameter("@course", saveSchedule.Course));
                    cmd.Parameters.Add(new SqlParameter("@group", saveSchedule.Group));
                    cmd.Parameters.Add(new SqlParameter("@subGroup", saveSchedule.SubGroup));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    saveSchedule.ScheduleId = (long)outPutId.Value;
                }
            }
        }

        public async Task<Schedule> FindByIdAsync(long id)
        {
            string queryString = "SELECT * FROM Schedules WHERE Id = @id";
            using(var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(queryString, sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = new Schedule();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = (long)reader["Id"];
                            result.Week = reader["Week"] == DBNull.Value ? 0 : (int)reader["Week"];
                            result.SubjectId = (int)reader["SubjectId"];
                            result.TeacherId = (string)reader["TeacherId"];
                            result.RoomId = (int)reader["RoomId"];
                            result.ActualGroupId = (int)reader["ActualGroupId"];
                            result.SubGroupId = (int)reader["SubGroupId"];
                            result.WeekDayId = (int)reader["WeekDayId"];
                            result.LessonNumId = (int)reader["LessonNumId"];
                        }
                    }

                    return result;
                }
            }
        }

        public async void Remove(Schedule schedule)
        {
            using (var sql = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("DeleteSchedule", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@scheduleId", schedule.Id));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
