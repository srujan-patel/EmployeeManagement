using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class EditEmployeeBase:ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            Employee= await EmployeeService.GetEmployee(int.Parse(Id));
            
            
        }

    }
}
