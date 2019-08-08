

using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class CalendarModel : IEntity
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}