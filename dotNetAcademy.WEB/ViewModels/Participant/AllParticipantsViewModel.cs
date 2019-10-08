using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.BLL.DTO;

namespace dotNetAcademy.WEB.ViewModels.Participant
{
    public class AllParticipantsViewModel
    {
        public string CustomerName { get; set; }
        public IEnumerable<ParticipantDTO> Participants { get; set; }
    }
}
