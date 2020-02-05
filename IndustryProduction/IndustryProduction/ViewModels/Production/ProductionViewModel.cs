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

        public decimal PlanCount { get; set; }
        public decimal ActualCount { get; set; }
        public decimal CompleteCount 
        {
            get 
            {
                var p1 = ActualCount / ((PlanCount == 0) ? 1 : PlanCount);
                var p2 = p1 * 100;
                return p2; 
            }
        }

        public int AvailableTime { get; set; }
        public string AvailableTimeHr { get; set; }
        public double TimePlan { get; set; }
        public int TimeProgress { get; set; }
        public int ProductionProgress { get; set; }
        public int PlanProgress { get; set; }
    }
}
