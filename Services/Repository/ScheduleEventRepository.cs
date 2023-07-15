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
            await connection.ExecuteAsync($"CREATE TABLE IF NOT EXISTS {_sqlServerOptions.ScheduleEventTableName} (PK_Event_ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                $"FK_Teacher_ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, FK_Subject_ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Title TEXT NOT NULL, " +
                $"Start_time TIME DEFAULT CURRENT_TIMESTAMP, End_time TIME DEFAULT CURRENT_TIMESTAMP, ModifiedDate DATE DEFAULT CURRENT_TIMESTAMP)").ConfigureAwait(false);
        }
    }
}
