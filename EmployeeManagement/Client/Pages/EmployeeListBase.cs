
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Pages
{
    public class EmployeeListBase: ComponentBase

    {  

        [Inject]
        public HttpClient _httpClient { get; set; }


        public List<Employee> Employees { get; set; }

        //[Inject]
        //public IEmployeeService EmployeeService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Employees = (await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees")).ToList();
        }

    }
}
