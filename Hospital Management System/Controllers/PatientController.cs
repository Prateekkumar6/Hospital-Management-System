using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.ActionFilters;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IPatientRepository patientRepo;
       

        public PatientController(HospitalManagmentDbContext dbContext, IPatientRepository patientRepo)
        {
            this.dbContext = dbContext;
            this.patientRepo = patientRepo;
          
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPatientList()
        {
            
            var patients= await patientRepo.GetAllAsync();
            return Ok(patients);
            
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetPatientById([FromRoute] Guid id)
        {
            var Patient = await patientRepo.GetById(id);   
            if (Patient == null)
            {
                return NotFound();
            }

            return Ok(Patient);
        }

        [HttpPost]
        [ValidateModelAttributes]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {

            await patientRepo.CreateAsync(patient);
            return Ok("New List Created");


        }
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModelAttributes]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Patient patient)
        {

            await patientRepo.UpdateAsync(id, patient);
            return Ok("New List Updated");
        }

        [HttpDelete]
        [Route("{id:guid}")]


        public async Task <IActionResult> Delete([FromRoute] Guid id) 
        
        {
            var deletePatient = await dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if(deletePatient==null)
            {
                return NotFound();
            }
           dbContext.Patients.Remove(deletePatient); 
           await dbContext.SaveChangesAsync();


           return Ok("deleted, New List Updated");
        }
    
    }

 


}
