namespace Schedule.Configuration
{
        public class SqlServerOptions : ISqlServerOptions
        {
            public string SqlServerConnection { get; set; }
            public string ScheduleEventTableName { get; set; }
        }
}
