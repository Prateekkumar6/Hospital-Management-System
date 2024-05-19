using Hospital_Management_System.Data;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.ActionFilters;
using Hospital_Management_System.Models.DomainModels;
namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IDoctorRepository repository;

        public DoctorController(HospitalManagmentDbContext dbContext, IDoctorRepository repository)
        {
            this.dbContext = dbContext;
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetDoctorList")]

        public async Task<IActionResult> GetAllDoctorsList()
        {

            var doctors = await repository.GetAllAsync();
            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDoctorByID([FromRoute]string id)
        {
            var doctor = await repository.GetById(id);
            if (doctor == null)
            {

              return NotFound();
            }
            return Ok(doctor);  
        }
        [HttpPost]
        [ValidateModelAttributes]
        
        public async Task<IActionResult> CreateAsync([FromBody] Doctor doctor)
        {
            await repository.CreateAsync(doctor);
            return CreatedAtAction("GetDoctorByID", new { ID = doctor.Id }, doctor);
        }
        [HttpPut]
        [Route("{id}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] Doctor doctor)
        {
            await repository.UpdateAsync(id, doctor);
            return Ok("New List Updated");
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await repository.DeleteAsync(id);
            return Ok("Deleted, Updated new List");
        }
    }
}
