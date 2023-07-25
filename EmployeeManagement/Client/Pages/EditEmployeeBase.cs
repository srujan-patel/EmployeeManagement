using AutoMapper;
using EmployeeManagement.Client.Models;
using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class EditEmployeeBase:ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }


        public List<Department> Departments { get; set; }= new List<Department>();

        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();


        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }


        protected async override Task OnInitializedAsync()
        {
            
            Employee= await EmployeeService.GetEmployee(int.Parse(Id));
            Departments =(await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }

        protected void HandleValidSubmit()
        {

        }

    }
}
