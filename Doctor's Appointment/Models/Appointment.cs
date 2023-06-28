namespace Doctor_s_Appointment.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string time { get; set; }
        public int age { get; set; }
        public DateTime date { get; set; }
    }
}
