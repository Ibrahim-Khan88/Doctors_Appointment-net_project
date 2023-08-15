using Doctor_s_Appointment.Interfaces;
using Doctor_s_Appointment.Models;

namespace Doctor_s_Appointment.Services
{
    public class AppointmentService : IAppointmentRepository
    {
        private readonly DataContext _datacontext;

        public AppointmentService(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public async Task<ServiceResponse<int>> CreateAppointment(Appointment appointment)
        {
            var response = new ServiceResponse<int>();
            _datacontext.Appointments.Add(appointment);
            await _datacontext.SaveChangesAsync();
            response.Data = appointment.Id;
            return response;
        }

        public async Task<ServiceResponse<List<List<Appointment>>>> getAllAppointmentByMonth(int monthNumber)
        {
            var response = new ServiceResponse<List<List<Appointment>>>();
            int currentYear = DateTime.Now.Year;
            var appoinments = await _datacontext.Appointments
                    .Where(appointment => appointment.date.Month == monthNumber && appointment.date.Year == currentYear)
                     .ToListAsync();
            response.Data = FormatAppionmentByDay(appoinments, monthNumber);
            return response;
        }

        private List<List<Appointment>> FormatAppionmentByDay(List<Appointment> appoinments, int monthNumber)
        {
            var appoinmentsFormatData = new List<List<Appointment>>();
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, monthNumber); i++)
            {
                appoinmentsFormatData.Add(new List<Appointment>());
            }

            foreach (var currentAppoinment in appoinments)
            {
                var day = currentAppoinment.date.Day - 1;
                appoinmentsFormatData[day].Add(currentAppoinment);
            }
            return appoinmentsFormatData;
        }
    }
}
