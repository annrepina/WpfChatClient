﻿using AutoMapper;
using DtoLib.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMessengerClient.Services;

namespace WpfMessengerClient.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<UserAccount, UserAccountDto>().ReverseMap();

            CreateMap<Dialog, DialogDto>().ReverseMap();

            CreateMap<Message, MessageDto>().ReverseMap();

            CreateMap<FrontClient, ClientDto>().ReverseMap();

            CreateMap<UserAccount, UserAccountRegistrationDto>().ForMember(nameof(UserAccountRegistrationDto.PhoneNumber), exp => exp.MapFrom(c => c.Person.PhoneNumber)).ReverseMap();
        }
    }
}
