using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class MachineWorking : DomainObject
    {
        [Column(TypeName = "int")]
        public int MachineId { get; set; }

        [Column(TypeName = "int")]
        public int ShiftId { get; set; }

        public Machine Machine { get; set; }

        public WorkingShift Shift { get; set; }
    }
}
