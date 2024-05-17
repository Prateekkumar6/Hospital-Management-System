using Hospital_Management_System.Data;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System.ActionFilters;
using Hospital_Management_System.Models.DomainModels;
using AutoMapper;
using Hospital_Management_System.Models.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IAppointmentRepository appointment;
        private readonly IMapper mapper;

        public AppointmentController(HospitalManagmentDbContext dbContext,IAppointmentRepository appointment, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.appointment = appointment;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllAppointment()
        {
              
            var Appointments= await appointment.GetAllListAsync();
            var appintmentdto = mapper.Map<List<AppointmentDTO>>(Appointments);
            if (Appointments==null) 
            {
                return NotFound();
            }
                
            return Ok(appintmentdto);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAppointmentByID([FromRoute] Guid id)
        {
            var Appointment = await appointment.GetListById(id);
            var appintmentdto = mapper.Map<AppointmentDTO>(Appointment);
            if (Appointment == null)
            {

                return NotFound();
            }
            return Ok(appintmentdto);
        }

        [HttpPost]
        [ValidateModelAttributes]

        public async Task<IActionResult> CreateListAsync([FromBody] AddAppointmentDTO addAppointment)
        {
            var addappointment = mapper.Map<Appointment>(addAppointment);
            addappointment= await appointment.CreateListAsync(addappointment);
            var addappointmentDTO= mapper.Map<AppointmentDTO>(addappointment);
            return Ok(addappointmentDTO);
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> UpdateListAsync([FromRoute] Guid id, [FromBody] Appointment updateAppointment)
        {
            await appointment.UpdateListAsync(id, updateAppointment);
            return Ok("New List Updated");
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteListAsync([FromRoute] Guid id)
        {
            await appointment.DeleteListAsync(id);  
            return Ok("Deleted, Updated new List");
        }
    }
}
