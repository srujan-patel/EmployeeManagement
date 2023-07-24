using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace EmployeeManagement.Client.Pages
{
    public class DatabindingBase: ComponentBase
    {
        //databindinng is used to bind frm a base class to razor view page
        protected string Name { get; set; } = "Tom";
        protected string Gender { get; set; } = "Male";

        protected string colour { get; set; } = "background-color:white";
    }
}
