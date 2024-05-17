using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System.ActionFilters;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IAppointmentRepository appointment;

        public AppointmentController(HospitalManagmentDbContext dbContext,IAppointmentRepository appointment)
        {
            this.dbContext = dbContext;
            this.appointment = appointment;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllAppointment()
        {
            var Appointments= await appointment.GetAllListAsync();
            if(Appointments==null) 
            {
                return NotFound();
            }
                
            return Ok(Appointments);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAppointmentByID([FromRoute] Guid id)
        {
            var Appointment = await appointment.GetListById(id);    
            if (Appointment == null)
            {

                return NotFound();
            }
            return Ok(Appointment);
        }

        [HttpPost]
        [ValidateModelAttributes]

        public async Task<IActionResult> CreateListAsync([FromBody] Appointment addAppointment)
        {
            await appointment.CreateListAsync(addAppointment);
            return CreatedAtAction("GetAppointmentByID", new { ID = addAppointment.Id },addAppointment);
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
