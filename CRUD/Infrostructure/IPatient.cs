using CRUD.Domain;

namespace CRUD.Infrostructure;

public interface IPatient
{
    bool CreatePatient(Patient patient);
    bool UpdatePatient(Patient patient);
    bool DeletePatient(int id);
    Patient? GetPatientById(int id);
    IEnumerable<Patient> GetAllPatients();
}