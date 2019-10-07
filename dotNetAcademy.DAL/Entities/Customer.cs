using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int MaxParticants { get; set; }

        //navigation properties
        public List<Participant> Participants { get; set; }

    }
}
