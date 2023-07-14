using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Schedule.Configuration;
using Schedule.Models;
using Schedule.Services.Repository.Base;
using System.Data;
using System.Data.SqlClient;

namespace Schedule.Services.Repository
{
    public class ScheduleEventRepository : BaseRepository<ScheduleEvent>, IScheduleEventRepository
    {
        //private readonly IDbConnection _dbConnection;

        //public ScheduleEventRepository(IDbConnection dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}

        //public async Task<IEnumerable<ScheduleEvent>> GetAllScheduleEventsAsync()
        //{
        //    return await _dbConnection.QueryAsync<ScheduleEvent>("SELECT * FROM Events");
        //}

        //public async Task<ScheduleEvent> GetScheduleEventByIdAsync(int id)
        //{
        //    return await _dbConnection.QuerySingleOrDefaultAsync<ScheduleEvent>("SELECT * FROM Events WHERE ID = @Id", new { Id = id });
        //}

        //public async Task<int> CreateScheduleEventAsync(ScheduleEvent scheduleEvent)
        //{
        //    const string sql = @"INSERT INTO Events(FK_Teacher_ID, FK_Subject_ID, Date, Title, Start_Time, End_Time)
        //                     VALUES(@TeacherID, @SubjectID, @Date, @Title, @StartTime, @EndTime);
        //                     SELECT CAST(SCOPE_IDENTITY() as int)";
        //    return await _dbConnection.ExecuteScalarAsync<int>(sql, scheduleEvent);
        //}

        //public async Task UpdateScheduleEventAsync(ScheduleEvent scheduleEvent)
        //{
        //    const string sql = @"UPDATE Events SET FK_Teacher_ID = @TeacherID, FK_Subject_ID = @SubjectID, Date = @Date,
        //                     Title = @Title, Start_Time = @StartTime, End_Time = @EndTime WHERE Id = @Id";
        //    await _dbConnection.ExecuteAsync(sql, scheduleEvent);
        //}

        //public async Task<int> DeleteAsync(int id)
        //{
        //    const string sql = @"DELETE FROM Events WHERE Id = @Id";
        //    await _dbConnection.ExecuteAsync(sql, new { Id = id });
        //}
        private readonly SqlServerOptions _sqlServerOptions;

        public ScheduleEventRepository(IOptions<SqlServerOptions> sqlServerOptions)
            : base(sqlServerOptions.Value.SqlServerConnection, sqlServerOptions.Value.ScheduleEventTableName)
        {
            _sqlServerOptions = sqlServerOptions.Value;
        }

        /// <summary>
        /// Create Products data table if not exists
        /// </summary>
        /// <returns></returns>
        public async Task CreateTableIfNotExistsAsync()
        {
            using var connection = new SqlConnection(_sqlServerOptions.SqlServerConnection);
            await connection.ExecuteAsync($"CREATE TABLE IF NOT EXISTS {_sqlServerOptions.ScheduleEventTableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name TEXT NOT NULL, " +
                $"Model TEXT NOT NULL, Price INTEGER NOT NULL, Obsolete BOOLEAN DEFAULT(FALSE), ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP)").ConfigureAwait(false);
        }
    }
}
