using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.DAL.Repositories.Interfaces;

namespace dotNetAcademy.BLL.Services.Customer
{
    public class CustomerService:ICustomerService
    {

        private readonly IGenericRepository<DAL.Entities.Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<DAL.Entities.Customer> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public CustomerDTO GetById(int id)
        {
            var customer = _repository.GetById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _repository.GetAll().ToList();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }
    }
}
