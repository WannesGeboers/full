using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.BLL.Services.CustomerService
{
    public interface ICustomerService
    {

        CustomerDTO GetById(int id);
        IEnumerable<CustomerDTO> GetAll();

        void Add(CustomerDTO customer);
        void Delete(int id);
        void Update(int id,CustomerDTO customer);

        void Save();
    }
}
