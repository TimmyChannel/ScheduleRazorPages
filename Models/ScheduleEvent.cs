using Newtonsoft.Json;

namespace Schedule.Models
{
	public class ScheduleEvent : Appointment
	{
		[JsonProperty(PropertyName = "TeacherId")]
		public int TeacherID { get; set; }
		[JsonProperty(PropertyName = "SubjectId")]
		public int SubjectID { get; set; }
	
	}
}
