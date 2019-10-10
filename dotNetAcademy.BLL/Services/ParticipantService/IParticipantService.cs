using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.BLL.Services.ParticipantService
{
    public interface IParticipantService
    {

        ParticipantDTO GetById(string id);
        IEnumerable<ParticipantDTO> GetAll();

        void Add(ParticipantDTO participant);
        void Delete(string id);
        void Update(string id, ParticipantDTO participant);

        void Save();

    }
}
