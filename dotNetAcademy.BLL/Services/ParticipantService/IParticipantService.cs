using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.BLL.Services.ParticipantService
{
    public interface IParticipantService
    {

        ParticipantDTO GetById(int id);
        IEnumerable<ParticipantDTO> GetAll();

        void Add(ParticipantDTO participant);
        void Delete(int id);
        void Update(int id, ParticipantDTO participant);

        void Save();

    }
}
