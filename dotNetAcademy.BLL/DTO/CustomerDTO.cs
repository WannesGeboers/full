using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.BLL.DTO
{
    public class CustomerDTO
    {
       public string Id { get; set; }
        public string Name { get; set; }
        public string StreetAndNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int MaxParticipants { get; set; }

        //navigation properties
        public IEnumerable<ParticipantDTO> Participants { get; set; }

    }
}
