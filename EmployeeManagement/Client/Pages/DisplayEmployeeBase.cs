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

        protected async Task CBChanged(ChangeEventArgs e)
        {

            await OnEmployeeSelection.InvokeAsync((bool)e.Value);



        }

    }
}
