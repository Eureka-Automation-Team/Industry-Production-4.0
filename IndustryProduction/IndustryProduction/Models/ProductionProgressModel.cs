using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.Models
{
    public class ProductionProgressModel
    {
        public ProductionProgressModel()
        {
            WorkingDays = new List<WorkingDay>();
            Shifts = new List<WorkingShift>();
            Alarms = new List<AlarmHistory>();
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
        public string MachineCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double AvailableTime { get; set; }
        public double ProductionProgress { get; set; }
        public double TimeProgress { get; set; }
        public double PlanVsAvailable { get; set; }
        public List<WorkingDay> WorkingDays { get; set; }
        public List<WorkingShift> Shifts { get; set; }
        public List<AlarmHistory> Alarms { get; set; }

        public double TaskStartTime { get; set; }
        public double TaskEndTime { get; set; }
    }

    public class WorkingDay
    {
        public WorkingDay()
        {
            ShiftTasks = new List<ShiftsDay>();
        }
        public DateTime WorkDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double StartHours
        {
            get
            {
                return Convert.ToDouble(StartDate.Hour);
            }
        }
        public double StartMinute
        {
            get
            {
                return Convert.ToDouble(StartDate.Minute);
            }
        }
        public int TotalHours
        {
            get
            {
                return Convert.ToInt32((EndDate - StartDate).TotalHours);
            }
        }
        public List<ShiftsDay> ShiftTasks { get; set; }
    }

    public class ShiftsDay
    {
        public ShiftsDay()
        {
            //Tasks = new List<JobEntityTaskModel>();
        }

        public int ShiftId { get; set; }
        public DateTime StartTime { get; set; }
        public int StartHr
        {
            get
            {
                return StartTime.Hour;
            }
        }
        public double StartMinute
        {
            get
            {
                return Convert.ToDouble(StartTime.Minute);
            }
        }
        public DateTime EndTime { get; set; }
        public int EndHr
        {
            get
            {
                return EndTime.Hour;
            }
        }
        public double EndMinute
        {
            get
            {
                return Convert.ToDouble(EndTime.Minute);
            }
        }
        public int TotalHr
        {
            get
            {
                return (EndTime - StartTime).Hours;
            }
        }

        public int TasksCount { get; set; }

        public List<JobEntityTaskModel> Tasks { get; set; }

        public double AvailableTime { get; set; }
        public double PlanTime { get; set; }
        public double ProgressTime { get; set; }
        public double ProductionTime { get; set; }
    }

    public class TaskSummary
    {
        public TaskSummary()
        {
            TasksAll = new List<JobEntityTaskModel>();
            TasksQueuing = new List<JobEntityTaskModel>();
            TasksRecord = new List<JobEntityTaskModel>();
            WorkingDays = new List<WorkingDay>();
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public decimal TasksPlanCount 
        { 
            get { return TasksQueuing.Count() + TasksRecord.Count(); }
        }
        public decimal TasksActualCount
        {
            get { return TasksRecord.Count(); }
        }
        public decimal CompletedPercentage
        {
            get { return (TasksActualCount / (TasksPlanCount == 0 ? 1 : TasksPlanCount)) * 100; }
        }
        public List<JobEntityTaskModel> TasksAll { get; set; }
        public List<JobEntityTaskModel> TasksQueuing { get; set; }
        public List<JobEntityTaskModel> TasksRecord { get; set; }

        public List<WorkingDay> WorkingDays { get; set; }
    }

    public class TasksQueuing : JobEntityTaskModel
    {
        public int Seq { get; set; }
        public string ProductionStatus { get; set; }
        public string PartNumber { get; set; }
        public string MachineCode { get; set; }
        public string RequiredDate { get; set; }
    }

    public class ProductionRecord : JobEntityTaskModel
    {
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string PartNumber { get; set; }
        public string SetupBy { get; set; }
        public string MachineTimeHr { get; set; }
    }
}
