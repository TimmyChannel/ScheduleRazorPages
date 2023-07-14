namespace Schedule.Configuration
{
    public interface ISqlServerOptions
    {
        string SqlServerConnection { get; set; }
        string ScheduleEventTableName { get; set; }
    }
}
