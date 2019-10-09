using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.DAL.Entities;
using dotNetAcademy.DAL.Repositories.Interfaces;

namespace dotNetAcademy.BLL.Services.ParticipantService
{
    public class ParticipantService:IParticipantService
    {

        private readonly IGenericRepository<Participant> _repository;
        private readonly IMapper _mapper;

        public ParticipantService(IGenericRepository<Participant> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public ParticipantDTO GetById(int id)
        {
            var product = _repository.GetById(id);

            return _mapper.Map<ParticipantDTO>(product);
        }

        public IEnumerable<ParticipantDTO> GetAll()
        {
            var allParticipants = _repository.GetAll().OrderBy(x=>x.Customer.Name);
            return _mapper.Map<IEnumerable<ParticipantDTO>>(allParticipants);
        }

        public void Add(ParticipantDTO product)
        {
            var p = _mapper.Map<Participant>(product);
            _repository.Insert(p);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(int id, ParticipantDTO participant)
        {
            var entity = _repository.GetById(id);
            _mapper.Map(participant, entity);
            Save();
        }
        public void Save()
        {
            _repository.Save();
        }


    }
}
