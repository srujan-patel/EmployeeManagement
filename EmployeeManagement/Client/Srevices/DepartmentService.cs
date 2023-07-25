using EmployeeManagement.Shared.Models;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Srevices
{



    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");

        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {

            return await _httpClient.GetFromJsonAsync<IEnumerable<Department>>("api/departments");
        }
    }
}
