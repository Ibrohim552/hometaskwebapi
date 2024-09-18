using System.Net;
using System.Net.Http.Json;

namespace TestProject;

public class PatientsService
{
    
    private readonly HttpClient _client;

    public PatientsService(HttpClient client)
    {
        _client = client;
    }

    public void CreatePatient(Patient patient)
    {
        JsonContent content = JsonContent.Create(patient);
        HttpResponseMessage response = _client.PostAsync("http://localhost:5032/Patient", content).Result;

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Patient created successfully");
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Patient creation failed");
        }
    }

    public void GetPatientById(int id)
    {
        HttpResponseMessage response = _client.GetAsync($"http://localhost:5032/Patient/{id}").Result;

        if (response.IsSuccessStatusCode)
        {
            Patient patient = response.Content.ReadFromJsonAsync<Patient>().Result;
            Console.WriteLine($"Patient with id {patient.Id} found:");
            Console.WriteLine($"{patient.Name} {patient.SurName}, {patient.Age} years old, sickness: {patient.Sickness}");
        }
        else
        {
            Console.WriteLine($"Patient with id {id} not found.");
        }
    }

    public void DeletePatientById(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"http://localhost:5032/Patient/{id}").Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Patient deleted successfully");
        }
        else
        {
            Console.WriteLine("Deleting was not successful");
        }
    }

    public void UpdatePatient(Patient patient)
    {
        JsonContent content = JsonContent.Create(patient);
        HttpResponseMessage response = _client.PutAsync("http://localhost:5032/Patient", content).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Patient updated successfully");
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Update failed");
        }
    }

    public void GetAllPatients()
    {
        HttpResponseMessage response = _client.GetAsync("http://localhost:5032/Patient").Result;
        if (response.IsSuccessStatusCode)
        {
            List<Patient> patients = response.Content.ReadFromJsonAsync<List<Patient>>().Result;
            Console.WriteLine("All Patients:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Id} - {patient.Name} {patient.SurName}, {patient.Age} years old, sickness: {patient.Sickness}");
            }
        }
        else
        {
            Console.WriteLine("Failed to retrieve patients");
        }
    }
        public void CheckAvailableMethods()
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Options, "http://localhost:5032/Patient");
        HttpResponseMessage response = _client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            IEnumerable<string> methods;
            if (response.Headers.TryGetValues("Allow", out methods))
            {
                Console.WriteLine("Supported methods: " + string.Join(", ", methods));
            }
        }
        else
        {
            Console.WriteLine("Failed to retrieve allowed methods.");
        }
    }

    public void CheckPatientExists(int id)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, $"http://localhost:5032/Patient/{id}");
        HttpResponseMessage response = _client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Patient with id {id} exists. Headers: {response.Headers}");
        }
        else
        {
            Console.WriteLine($"Patient with id {id} does not exist.");
        }
    }

    public void PatchPatient(int id, object updateData)
    {
        JsonContent content = JsonContent.Create(updateData);
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://localhost:5032/Patient/{id}")
        {
            Content = content
        };
        HttpResponseMessage response = _client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Patient updated successfully (partially)");
        }
        else
        {
            Console.WriteLine("Failed to partially update patient.");
        }
    }

    public void TraceRequestPath()
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Trace, "http://localhost:5032/trace");
        HttpResponseMessage response = _client.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            string traceContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"Trace result: {traceContent}");
        }
        else
        {
            Console.WriteLine("Failed ");
        }
    }
}
