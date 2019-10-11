using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dotNetAcademy.BLL.DTO
{
    public class FlatParticipantDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime StartDate { get; set; }
        //[DataType(DataType.Date),DisplayFormat(ApplyFormatInEditMode = true,DataFormatString="{0:d}")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime EndDate { get; set; }
        public string CustomerId { get; set; }
        
    }
}
