using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeletion { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected async Task CBChanged(ChangeEventArgs e)
        {

            await OnEmployeeSelection.InvokeAsync((bool)e.Value);



        }

        protected async Task DeleteClick()
        {
           await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeletion.InvokeAsync(Employee.EmployeeId);

            //NavigationManager.NavigateTo("/", true);

        }

    }
}
