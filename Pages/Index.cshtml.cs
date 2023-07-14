using Schedule.Models;
using Schedule.Services.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Schedule.Pages
{
    /// <summary>
    /// Index Page Model
    /// </summary>
    public class IndexModel : PageModel
    {
        readonly IScheduleEventRepository _eventRepository;

        public IndexModel(IScheduleEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _eventRepository.CreateTableIfNotExistsAsync();
        }

        [BindProperty]
        public IEnumerable<ScheduleEvent> Events { get; set; }

        /// <summary>
        /// Initializes any state needed for the page, in our case Products List
        /// </summary>
        public async Task OnGetAsync()
        {
            Events = await _eventRepository.GetAsync().ConfigureAwait(false);
        }
    }
}