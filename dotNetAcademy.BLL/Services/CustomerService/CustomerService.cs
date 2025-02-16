﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.DTO;
using dotNetAcademy.DAL.Entities;
using dotNetAcademy.DAL.Repositories.Interfaces;

namespace dotNetAcademy.BLL.Services.CustomerService
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

        public CustomerDTO GetById(string id)
        {
            var customer = _repository.GetById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _repository.GetAll().ToList();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public void Add(CustomerDTO customer)
        {
            var p = _mapper.Map<Customer>(customer);
            _repository.Insert(p);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public void Update(string id,CustomerDTO customer)
        {
            var entity = _repository.GetById(id);
            _mapper.Map(customer, entity);
            var x = customer;
            var y = entity;
            Save();
        }
        public void Save()
        {
            _repository.Save();
        }
    }
}
