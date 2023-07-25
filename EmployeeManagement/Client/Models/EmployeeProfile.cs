using AutoMapper;
using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Client.Models
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile() {

            CreateMap<Employee, EditEmployeeModel>().ForMember(
                dest=>dest.ConfirmEmail, opt=>opt.MapFrom(src=>src.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
