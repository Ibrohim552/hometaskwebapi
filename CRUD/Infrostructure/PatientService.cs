using CRUD.Domain;
using Dapper;
using Npgsql;

namespace CRUD.Infrostructure;

public class PatientService() :IPatient
{
    public bool CreatePatient(Patient patient)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return connection.Execute(SqlCommands.InsertPatient, patient) > 0;
        }
    }

    public bool UpdatePatient(Patient patient)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return connection.Execute(SqlCommands.UpdatePatient, patient) > 0;
        }
    }

    public bool DeletePatient(int id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return connection.Execute(SqlCommands.DeletePatient, new{Id=id}) > 0;
        }
    }

    public Patient? GetPatientById(int id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return connection.QuerySingleOrDefault<Patient>(SqlCommands.GetPatientById, new{Id=id});
        }
    }

    public IEnumerable<Patient> GetAllPatients()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.connectionstring))
        {
            connection.Open();
            return connection.Query<Patient>(SqlCommands.GetAllPatients);
        }
    }
}