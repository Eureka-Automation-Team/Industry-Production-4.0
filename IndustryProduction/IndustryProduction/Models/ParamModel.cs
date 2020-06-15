using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class ParamModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MachineCode { get; set; }
        public string MachineGroup { get; set; }
        public string MachineModel { get; set; }
        public string ProductionLine { get; set; }
    }
}
