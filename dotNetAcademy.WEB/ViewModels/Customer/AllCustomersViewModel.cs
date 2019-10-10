using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.WEB.ViewModels.Customer
{
    public class AllCustomersViewModel
    {
        public int Members;
        public IEnumerable<CustomerDTO> Customers { get; set; }

    }
}
