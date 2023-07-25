using AutoMapper;
using EmployeeManagement.Client.Models;
using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace EmployeeManagement.Client.Pages
{
    public class EditEmployeeBase : ComponentBase
    {

        public string PageHeaderText { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }


        public List<Department> Departments { get; set; } = new List<Department>();

        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }


        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeID);

            if (employeeID != 0)
            {
                PageHeaderText = "Edit Employee";

                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";

                Employee = new Employee
                {
                    DepartmentID = 1,
                    DateofBirth = DateTime.Now,
                    PhotoPath = "images/p1.png"
                };
            }
            //Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {


            Employee result = null;

            Mapper.Map(EditEmployeeModel, Employee);
            if (Employee.EmployeeId != 0) {

               result = await EmployeeService.UpdateEmployee(Employee);

            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee); 

            }

            if (result != null)
            {

                NavigationManager.NavigateTo("/");
            }


        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");

        }
    }
}
