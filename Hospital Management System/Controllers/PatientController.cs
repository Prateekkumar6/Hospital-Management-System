using Hospital_Management_System.Data;
using Hospital_Management_System.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.ActionFilters;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Hospital_Management_System.Models.DomainModels;
using AutoMapper;
using Hospital_Management_System.Models.DTO;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalManagmentDbContext dbContext;
        private readonly IPatientRepository patientRepo;
        private readonly IMapper mapper;

        public PatientController(HospitalManagmentDbContext dbContext, IPatientRepository patientRepo,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.patientRepo = patientRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllPatientList")]

        public async Task<IActionResult> GetAllPatientList()
        {
            
            var patients= await patientRepo.GetAllAsync();

            var patientsdto=mapper.Map<List<PatientDTO>>(patients);
            
            return Ok(patientsdto);

        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetPatientById([FromRoute] Guid id)
        {
            var Patient = await patientRepo.GetById(id);
            var patientsdto = mapper.Map<PatientDTO>(Patient);

            if (Patient == null)
            {
                return NotFound();
            }

            return Ok(patientsdto);
        }

        [HttpPost]
        [ValidateModelAttributes]
        public async Task<IActionResult> Create([FromBody] addPateintDTO addPateint)
        {
            var addPatient  = mapper.Map<Patient>(addPateint);

            addPatient= await patientRepo.CreateAsync(addPatient);


            var patientdto= mapper.Map<PatientDTO>(addPatient);
            
            return Ok(patientdto);


        }
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModelAttributes]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePatientDTO updatePatientDTO)
        {
            var updateData = mapper.Map<Patient>(updatePatientDTO);
            updateData=  await patientRepo.UpdateAsync(id,updateData);
            if(updateData== null)
            {
                return NotFound(id);
            }
            var updatedataDTO = mapper.Map<PatientDTO>(updateData);
            return Ok(updatedataDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]


        public async Task <IActionResult> Delete([FromRoute] Guid id) 
        
        {
            var deletePatient= await patientRepo.DeleteAsync(id);   
            if(deletePatient== null)
            {
                return NotFound();
            }
            var deletePatientDTO = mapper.Map<PatientDTO>(deletePatient);
           return Ok(deletePatientDTO);
        }
    
    }

 


}
