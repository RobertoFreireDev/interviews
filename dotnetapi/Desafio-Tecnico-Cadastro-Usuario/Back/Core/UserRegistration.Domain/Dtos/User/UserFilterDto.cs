using System;

namespace UserRegistration.Domain.Dtos.User
{
    public class UserFilterDto
    {
        public Filter[] Filters { get; set; }
    }

    public class Filter
    {
        public string Field { get; set; }
        public string Value { get; set; }     
    }
}