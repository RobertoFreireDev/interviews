using System;

namespace UserRegistration.Application.DataContracts.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
    }
}
