using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.BLL.Services.CustomerService
{
    public interface ICustomerService
    {

        CustomerDTO GetById(string id);
        IEnumerable<CustomerDTO> GetAll();

        void Add(CustomerDTO customer);
        void Delete(string id);
        void Update(string id,CustomerDTO customer);

        void Save();
    }
}
