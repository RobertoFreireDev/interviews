using System;

namespace UserRegistration.Domain.Dtos.User
{
    public class UserToggleActivationDto
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
