using Schedule.Models;
using Schedule.Services.Repository.Base;

namespace Schedule.Services.Repository
{
    public interface IScheduleEventRepository : IBaseRepository<ScheduleEvent>
    {
        Task CreateTableIfNotExistsAsync();
    }
}
