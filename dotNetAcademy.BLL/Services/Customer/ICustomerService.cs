using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.BLL.Services.Customer
{
    public interface ICustomerService
    {

        CustomerDTO GetById(int id);
        IEnumerable<CustomerDTO> GetAll();
    }
}
