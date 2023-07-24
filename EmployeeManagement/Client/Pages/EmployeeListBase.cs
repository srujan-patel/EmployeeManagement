
using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace EmployeeManagement.Client.Pages
{
    public class EmployeeListBase: ComponentBase

    {  

        [Inject]
        public IEmployeeService EmployeeService { get; set; }


        public List<Employee> Employees { get; set; }

        //[Inject]
        //public IEmployeeService EmployeeService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Employees = (await  EmployeeService.GetEmployees()).ToList();
        }

    }
}
