﻿
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


        public List<Employee> Employees { get; set; } = new List<Employee>();


        //[Inject]
        //public IEmployeeService EmployeeService { get; set; }

        public bool ShowFooter { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Employees = (await  EmployeeService.GetEmployees()).ToList();
        }



        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }


        protected async Task EmployeeDeleted()
        {
            Employees= (await EmployeeService.GetEmployees()).ToList();
        }

    }
}
