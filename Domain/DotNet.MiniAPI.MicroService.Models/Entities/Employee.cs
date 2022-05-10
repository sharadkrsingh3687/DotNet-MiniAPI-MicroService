namespace DotNet.MiniAPI.MicroService.Models.Entities
{
    public class Employee
    {
        public Guid? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
    }    
}
