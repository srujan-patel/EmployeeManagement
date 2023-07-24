using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

    }
}
