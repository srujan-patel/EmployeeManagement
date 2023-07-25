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

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
           var response= await _httpClient.PutAsJsonAsync("api/employees", updatedEmployee);
            return await response.Content.ReadFromJsonAsync<Employee>();


        }

        public async Task<Employee> CreateEmployee(Employee updatedEmployee)
        {

            var response = await _httpClient.PostAsJsonAsync("api/employees", updatedEmployee);
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task DeleteEmployee(int Id)
        {
            await _httpClient.DeleteAsync($"api/employees/{Id}");

        }
    }
}
