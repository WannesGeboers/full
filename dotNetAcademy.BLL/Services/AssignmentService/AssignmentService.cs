using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.DAL.Entities;
using dotNetAcademy.DAL.Repositories.Interfaces;

namespace dotNetAcademy.BLL.Services.AssignmentService
{
    public class AssignmentService
    {

        private readonly IGenericRepository<Assignment> _repository;
        private readonly IMapper _mapper;

        public AssignmentService(IGenericRepository<Assignment> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public AssignmentDTO GetById(string id)
        {
            var assignment = _repository.GetById(id);
            return _mapper.Map<AssignmentDTO>(assignment);
        }

        public IEnumerable<AssignmentDTO> GetAll()
        {
            var assignments = _repository.GetAll().ToList();
            return _mapper.Map<IEnumerable<AssignmentDTO>>(assignments);
        }

        public void Add(AssignmentDTO assignment)
        {
            var p = _mapper.Map<Assignment>(assignment);
            _repository.Insert(p);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public void Update(string id, AssignmentDTO assignment)
        {
            var entity = _repository.GetById(id);
            _mapper.Map(assignment, entity);
            Save();
        }
        public void Save()
        {
            _repository.Save();
        }
    }
}

