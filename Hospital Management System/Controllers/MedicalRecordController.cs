using Hospital_Management_System.Data;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_System.ActionFilters;
using Hospital_Management_System.Models.DomainModels;
using Hospital_Management_System.Models.DTO;
using AutoMapper;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IMedicalRecordRepository medicalRecordRepository;
        private readonly IMapper mapper;

        public MedicalRecordController(HospitalManagmentDbContext dbContext,IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.medicalRecordRepository = medicalRecordRepository;
            this.mapper = mapper;
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

        public async Task<IActionResult> CreateListAsync([FromBody] AddMedicalRecordDTO addRecord)
        {
            var addrecord = mapper.Map<MedicalRecord>(addRecord);
            addrecord=  await medicalRecordRepository.CreateListAsync(addrecord);
            var addrecorddto = mapper.Map<AddMedicalRecordDTO>(addrecord);
            return Ok(addrecorddto);
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
