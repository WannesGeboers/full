using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace dotNetAcademy.DAL.Entities
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
        public string StreetAndNumber { get; set; }
        public string City { get; set; }
        public int MaxParticipants { get; set; }

        //navigation properties
        public virtual List<Participant> Participants { get; set; }
    }
}
