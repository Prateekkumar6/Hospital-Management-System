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
    public class MedicalRecordController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecordController(HospitalManagmentDbContext dbContext,IMedicalRecordRepository medicalRecordRepository)
        {
            this.dbContext = dbContext;
            this.medicalRecordRepository = medicalRecordRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var Records = await medicalRecordRepository.GetAllListAsync();
            if (Records == null)
            {
                return NotFound();
            }

            return Ok(Records);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAppointmentByID([FromRoute] Guid id)
        {
            var Records = await medicalRecordRepository.GetListById(id);
            if (Records == null)
            {

                return NotFound();
            }
            return Ok(Records);
        }

        [HttpPost]
        [ValidateModelAttributes]

        public async Task<IActionResult> CreateListAsync([FromBody] MedicalRecord addRecord)
        {
            await medicalRecordRepository.CreateListAsync(addRecord);
            return CreatedAtAction("GetAppointmentByID", new { ID = addRecord.Id }, addRecord);
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> UpdateListAsync([FromRoute] Guid id, [FromBody] MedicalRecord updateRecord)
        {
            await medicalRecordRepository.UpdateListAsync(id, updateRecord);
            return Ok("New List Updated");
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteListAsync([FromRoute] Guid id)
        {
            await medicalRecordRepository.DeleteListAsync(id);
            return Ok("Deleted, Updated new List");
        }
    }
}
