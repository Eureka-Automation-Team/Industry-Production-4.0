using IndustryProduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.ViewModels.Production
{
    public class ProductionViewModel
    {
        public MachineModel Machine { get; set; }
        public List<JobEntityTaskModel> Tasks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string prodModel { get; set; }
    }
}
