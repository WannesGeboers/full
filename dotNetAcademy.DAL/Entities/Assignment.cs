using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dotNetAcademy.DAL.Entities
{
    public class Assignment
    {

        public string Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
      
        public int Quota { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ParticipantId { get; set; }
    }
}
