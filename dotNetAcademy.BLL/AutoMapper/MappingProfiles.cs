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
            //.ForMember(x=>x.Participants,opt => opt.Ignore())
        .ReverseMap();

        CreateMap<Participant, ParticipantDTO>()
            .ReverseMap();
        }
    }
}
