namespace CRUD.Domain;

public class SqlCommands
{
    public const string connectionstring = "Server=localhost;Port=5432;Database=Hospital;User Id=postgres;Password=postgres;";
    public const string GetAllPatients = "SELECT * FROM patient";
    public const string InsertPatient = "INSERT INTO patient (name, surname, age, sickness) VALUES (@name, @surname, @age, @sickness)";
    public const string UpdatePatient = "UPDATE patient SET name=@name, surname=@surname, age=@age, sickness=@sickness WHERE id=@id";
    public const string DeletePatient = "DELETE FROM patient WHERE id=@id";
    public const string GetPatientById = "SELECT * FROM patient WHERE id=@id";
}