using Schedule.Models;
using Schedule.Services.Repository;

namespace Schedule.Services
{
    public class ScheduleEventService
    {
        private readonly IScheduleEventRepository _scheduleEventRepository;

        public ScheduleEventService(IScheduleEventRepository scheduleEventRepository)
        {
            _scheduleEventRepository = scheduleEventRepository;
        }

        public async Task<IEnumerable<ScheduleEvent>> GetAllScheduleEventsAsync()
        {
            return await _scheduleEventRepository.GetAllScheduleEventsAsync();
        }

        public async Task<ScheduleEvent> GetScheduleEventByIdAsync(int id)
        {
            return await _scheduleEventRepository.GetScheduleEventByIdAsync(id);
        }

        public async Task<int> CreateScheduleEventAsync(ScheduleEvent scheduleEvent)
        {
            return await _scheduleEventRepository.CreateScheduleEventAsync(scheduleEvent);
        }

        public async Task UpdateScheduleEventAsync(ScheduleEvent scheduleEvent)
        {
            await _scheduleEventRepository.UpdateScheduleEventAsync(scheduleEvent);
        }

        public async Task DeleteScheduleEventAsync(int id)
        {
            await _scheduleEventRepository.DeleteScheduleEventAsync(id);
        }
    }
}
