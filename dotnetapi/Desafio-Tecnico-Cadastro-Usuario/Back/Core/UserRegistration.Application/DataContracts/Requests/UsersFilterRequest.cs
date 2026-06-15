using UserRegistration.Domain.Dtos.User;

namespace UserRegistration.Application.DataContracts.Requests
{
    public class UsersFilterRequest
    {
        public Filter[] Filters { get; set; }
    }
}
