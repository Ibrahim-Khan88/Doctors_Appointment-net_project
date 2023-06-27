using Doctor_s_Appointment.Models;

namespace Doctor_s_Appointment.DataRepository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
