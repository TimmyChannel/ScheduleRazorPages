namespace Schedule.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
