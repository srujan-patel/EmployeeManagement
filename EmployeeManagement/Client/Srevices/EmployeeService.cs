using EmployeeManagement.Shared.Models;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Srevices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient) { 
        _httpClient =  httpClient;
        
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");


        }

        public async Task <Employee> GetEmployee(int Id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employees/{Id}");
        }
    }
}
