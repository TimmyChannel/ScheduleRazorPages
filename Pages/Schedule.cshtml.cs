using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schedule.Models;
using Schedule.Services.Repository;

namespace Schedule.Pages
{
    public class ScheduleModel : PageModel
    {
        private readonly IScheduleEventRepository _eventRepository;
        public ScheduleModel(IScheduleEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _eventRepository.CreateTableIfNotExistsAsync();
        }

        [BindProperty]
        public IEnumerable<ScheduleEvent> Events { get; set; }
        public async Task OnGetAsync()
        {
            Events = await _eventRepository.GetAsync().ConfigureAwait(false);
        }
    }
}
