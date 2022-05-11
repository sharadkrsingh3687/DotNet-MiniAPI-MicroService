namespace DotNet.MiniAPI.MicroService.Models.Response
{
    public class EmployeeResponse
    {
        public Guid? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AddressResponse Address { get; set; }
        public bool IsActive { get; set; }
    }
}
