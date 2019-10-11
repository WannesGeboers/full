using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.DAL.Entities;

namespace dotNetAcademy.BLL.AutoMapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
        CreateMap<Customer,CustomerDTO>()
            
        .ReverseMap();

        CreateMap<Participant, ParticipantDTO>()
           .ReverseMap();

        CreateMap<Customer, CustomerNoChildsDTO>()
            .ReverseMap();

        CreateMap<Participant, FlatParticipantDTO>()
            .ReverseMap();
        }

    }
    
}
