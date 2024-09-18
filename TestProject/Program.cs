using TestProject;

HttpClient client = new HttpClient();
PatientsService patientService = new PatientsService(client);

//patientService.CreatePatient(new Patient { Id = 2, Name = "Yusuf", SurName = "Rustamov", Age = 15, Sickness = "Flu" });
// patientService.GetPatientById(3);
// patientService.DeletePatientById(2);
// patientService.UpdatePatient(new Patient { Id = 3, Name = "Xush", SurName = "Someone", Age = 17, Sickness = "Flu" });
// patientService.GetAllPatients();