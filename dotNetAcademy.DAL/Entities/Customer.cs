using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAndNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int MaxParticants { get; set; }

        //navigation properties
        public virtual List<Participant> Participants { get; set; }

    }
}
