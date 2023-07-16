namespace Schedule.Models
{
	public static class bibob
	{
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
		public static IEnumerable<Appointment> Adppointments { get; }
		public static readonly IEnumerable<Appointment> Appointments = new[]
		{
			new Appointment
			{
				AppointmentId= 1,
				StartDate= "2023-07-15T11:30:00.000Z",
				EndDate= "2023-07-15T15:30:00.000Z",
				Text="Bibob"
			}
		};
	}
}
