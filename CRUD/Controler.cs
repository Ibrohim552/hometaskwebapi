using CRUD.Domain;
using CRUD.Infrostructure;
using Microsoft.AspNetCore.Mvc;
namespace hometaskWeb.Controller;


[Route("Patient")]
[ApiController]
public class PatientController
{
    private readonly PatientService _patientService = new PatientService();

    [HttpPost]
    public bool CreatePatient(Patient patient)
    {
        return _patientService.CreatePatient(patient);
    }

    [HttpPut]
    public bool UpdatePatient(Patient patient)
    {
        return _patientService.UpdatePatient(patient);
    }

    [HttpDelete("{id}")]
    public bool DeletePatient(int id)
    {
        return _patientService.DeletePatient(id);
    }

    [HttpGet("{id}")]
    public Patient? GetPatientById(int id)
    {
        return _patientService.GetPatientById(id);
    }

    [HttpGet]
    public IEnumerable<Patient> GetAllPatient()
    {
        return _patientService.GetAllPatients();
    }
}
