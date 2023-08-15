using Doctor_s_Appointment.Models;

namespace Doctor_s_Appointment.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<ServiceResponse<int>> CreateAppointment(Appointment loan);
        Task<ServiceResponse<List<List<Appointment>>>> getAllAppointmentByMonth(int monthNumber);
    }
}
