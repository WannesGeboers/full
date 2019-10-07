using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Entities
{
    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
