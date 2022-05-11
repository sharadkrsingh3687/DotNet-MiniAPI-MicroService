using AutoMapper;
using DotNet.MiniAPI.MicroService.Models.Entities;
using DotNet.MiniAPI.MicroService.Models.Response;

namespace DotNet.MiniAPI.MicroService.Business.Mapper
{
    public class ProfileMapper: Profile
    {
        public ProfileMapper()
        {
            this.CreateMap<Employee, EmployeeResponse>();
            this.CreateMap<Address, AddressResponse>();
        }
    }
}
