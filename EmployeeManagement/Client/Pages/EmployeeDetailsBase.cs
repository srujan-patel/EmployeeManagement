﻿using EmployeeManagement.Client.Srevices;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {
        public Employee Employee { get; set; }= new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee= await EmployeeService.GetEmployee(int.Parse(Id));
        }

    }
}
