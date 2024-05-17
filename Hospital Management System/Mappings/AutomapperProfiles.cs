using AutoMapper;
using Hospital_Management_System.Models.DomainModels;
using Hospital_Management_System.Models.DTO;

namespace Hospital_Management_System.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<addPateintDTO,Patient>().ReverseMap();
            CreateMap<UpdatePatientDTO, Patient>().ReverseMap();
            CreateMap<AppointmentDTO, Appointment>().ReverseMap();
            CreateMap<AddAppointmentDTO, Appointment>().ReverseMap();
            CreateMap<AddMedicalRecordDTO, MedicalRecord>().ReverseMap();

        }
    }
}
