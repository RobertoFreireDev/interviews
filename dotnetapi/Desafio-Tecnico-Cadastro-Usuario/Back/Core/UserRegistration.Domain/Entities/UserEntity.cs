using System;
using UserRegistration.Domain.Entities.Base;

namespace UserRegistration.Domain.Entities
{
    public class UserEntity : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
    }
}