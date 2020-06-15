using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class OeeReportModel 
    {
        public OeeReportModel()
        {
            Machine = new Machine();
            MachineWorking = new List<MachineWorking>();
            TasksAll = new List<JobEntityTaskModel>();
            OeeLine = new List<OEELineModel>();
        }
        public List<OEELineModel> OeeLine { get; set; }
        public Machine Machine { get; set; }
        public List<MachineWorking> MachineWorking { get; set; }
        public List<JobEntityTaskModel> TasksAll { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double PlanningUtilization { get; set; }
        public double ProcessUtilization
        {
            get
            {
                return Math.Round((ProductionTimeHr / (AvailableTimeHr == 0 ? 1 : AvailableTimeHr)) * 100, 2);
            }
        }
        public decimal Actual { get; set; }
        public decimal PlanninPcs { get; set; }
        public decimal Reject { get; set; }
        public decimal Rework { get; set; }
        public double Performance
        {
            get
            {
                return Convert.ToDouble(Actual / (PlanninPcs == 0 ? 1 : PlanninPcs)) * 100;
            }
        }
        public double Quality
        {
            get
            {
                decimal resutl = (((Reject + Rework) == 0 ? 1 : (Reject + Rework) / Actual) * 100);
                return Convert.ToDouble(Math.Round((Actual == 0 ) ? 0 : resutl, 2));
                
            }
        }
        public double OEE
        {
            get
            {
                //return Math.Round(((QualitySummary * ProductivitySummary * ProcessUtilizationSummary) / 100) / 100, 3);
                return Math.Round(((Quality * Performance * ProcessUtilization) / 100) / 100, 3);
            }
        }
        public int QcPass { get; set; }
        public int QcNG { get; set; }
        public int Hold { get; set; }

        #region Process Utilization
        public double AvailableTimeMin { get; set; }
        public double AvailableTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(AvailableTimeMin) / 60;
                int Minute = Convert.ToInt32(AvailableTimeMin) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double PlanningTimeMin { get; set; }
        public double PlanningTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(PlanningTimeMin) / 60;
                int Minute = Convert.ToInt32(PlanningTimeMin) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double ProductionTimeMin { get; set; }
        public double ProductionTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(ProductionTimeMin) / 60;
                int Minute = Convert.ToInt32(ProductionTimeMin) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double MachineTimeMin { get; set; }
        public double MachineTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(MachineTimeMin) / 60;
                int Minute = Convert.ToInt32(MachineTimeMin) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double LoadingTimeHr { get; set; }
        public double UnloadingimeHr { get; set; }
        public double MaintenanceTimeHr { get; set; }
        public double BreakdownTimeHr { get; set; }
        public double SettingTimeHr { get; set; }
        #endregion
    }

    public class OEELineModel
    {
        public string MachineCode { get; set; }
        public double AvailableTimeHr { get; set; }
        public double PlanningTimeHr { get; set; }
        public double ProductionTimeHr { get; set; }
        public double PlanUtilization { get; set; }
        public double ProcessUtilization { get; set; }
        public decimal Actual { get; set; }
        public decimal PlanninPcs { get; set; }
        public decimal Reject { get; set; }
        public decimal Rework { get; set; }
        public double Performance { get; set; }
        public double Quality { get; set; }
        public double OEE { get; set; }
        public int QcPass { get; set; }
        public int QcNG { get; set; }
        public int Hold { get; set; }
    }
}
