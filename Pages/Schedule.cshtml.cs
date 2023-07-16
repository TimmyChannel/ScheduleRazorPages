using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Schedule.Models;
using Schedule.Services.Repository;

namespace Schedule.Pages
{
	public class ScheduleModel : PageModel
	{
		//private readonly IScheduleEventRepository _eventRepository;
		//public ScheduleModel(IScheduleEventRepository eventRepository)
		//{
		//    _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
		//    _eventRepository.CreateTableIfNotExistsAsync();
		//}

		//[BindProperty]
		//public IEnumerable<ScheduleEvent> Events { get; set; }
		//public async Task OnGetAsync()
		//{
		//    Events = await _eventRepository.GetAsync().ConfigureAwait(false);
		//}
		public static IEnumerable<ScheduleEvent> Events { get => _events; set => _events = value; }
		private static IEnumerable<ScheduleEvent> _events = new[]
		{
			new ScheduleEvent
			{
				AppointmentId = 1,
				TeacherID = 1,
				SubjectID = 1,
				StartDate= "2023-07-15T18:30:00.000Z",
				EndDate= "2023-07-15T20:30:00.000Z",
				Text="ABOBA"
			},
			new ScheduleEvent
			{
				AppointmentId = 2,
				TeacherID = 2,
				SubjectID = 2,
				StartDate= "2023-07-15T11:30:00.000Z",
				EndDate= "2023-07-15T15:30:00.000Z",
				Text="Bibob"
			}
		};

		public IActionResult OnGetGetData(DataSourceLoadOptions loadOptions)
		{
			var events = new List<ScheduleEvent>
		{
			new ScheduleEvent
			{
				AppointmentId = 1,
				TeacherID = 1,
				SubjectID = 1,
				StartDate= "2021-07-15T18:30:00.000Z",
				EndDate= "2021-07-15T20:30:00.000Z",
				Text="ABOBA"
			},
			new ScheduleEvent
			{
				AppointmentId = 2,
				TeacherID = 2,
				SubjectID = 2,
				StartDate= "2021-07-15T11:30:00.000Z",
				EndDate= "2021-07-15T15:30:00.000Z",
				Text="Bibob"
			}
		};

			var data = DataSourceLoader.Load(events, loadOptions);
			return new JsonResult(data);
		}
		public IActionResult OnPostAddData(string values)
		{
			var newEvent = new ScheduleEvent();
			JsonConvert.PopulateObject(values, newEvent);
			newEvent.AppointmentId = Events.Max(e => e.AppointmentId) + 1;
			Events = Events.Append(newEvent);

			return new JsonResult(new { newEvent.AppointmentId });
		}

		public IActionResult OnPutUpdateData(int key, string values)
		{
			var eventToUpdate = Events.FirstOrDefault(e => e.AppointmentId == key);
			JsonConvert.PopulateObject(values, eventToUpdate);

			return new JsonResult(null);
		}

		public IActionResult OnDeleteDeleteData(int key, string values)
		{
			Events = Events.Where(e => e.AppointmentId != key);

			return new JsonResult(null);
		}
	}
}

