using Doctor_s_Appointment.Interfaces;
using Doctor_s_Appointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_s_Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> createAppointment(Appointment appointment)
        {
            var response = await _appointmentRepository.CreateAppointment(appointment);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{monthNumber}")]
        public async Task<ActionResult<ServiceResponse<List<List<Appointment>>>>> getAllAppointmentByMonth(int monthNumber)
        {
            var response = await _appointmentRepository.getAllAppointmentByMonth(monthNumber);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
