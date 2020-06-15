using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class WorkingShift : DomainObject
    {
        [Display(Name = "Shift")]
        [Column(TypeName = "nvarchar(50)")]
        public string ShiftName { get; set; }

        [Display(Name = "Start Time")]
        [Column(TypeName = "datetime2(7)")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [Column(TypeName = "datetime2(7)")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Total (hr)")]
        [Column(TypeName = "int")]
        public int WorkingHr { get; set; }

        [Display(Name = "Total (min)")]
        [Column(TypeName = "int")]
        public int WorkingMin { get; set; }
    }
}
