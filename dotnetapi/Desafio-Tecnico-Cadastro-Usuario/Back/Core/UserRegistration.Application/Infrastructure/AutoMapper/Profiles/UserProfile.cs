using AutoMapper;
using System;
using UserRegistration.Application.DataContracts.Responses;
using UserRegistration.Domain.Entities;
using UserRegistration.Domain.Dtos.User;
using UserRegistration.Application.DataContracts.Requests;
using UserRegistration.Domain.Dtos;

namespace UserRegistration.Application.Infrastructure.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserDto, UserResponse>();
            CreateMap<UsersFilterRequest, UserFilterDto>();
            CreateMap<UserRequest, UserDto>().ForMember(dest => dest.BirthDate, opt => opt.MapFrom(
                        src => new DateTime(src.BirthDate.Year, src.BirthDate.Month, src.BirthDate.Day)
                    ));
            CreateMap<UserToggleActivationRequest, UserToggleActivationDto>();         
        }
    }
}
