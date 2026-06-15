using System;

namespace UserRegistration.Application.DataContracts.Requests
{
    public class UserToggleActivationRequest
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
