using IndustryProduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryProduction.ViewModels.OeeReport
{
    public class OEEViewModel
    {

        //Data
        public List<MachineModel> Machines { get; set; }
        public List<JobEntityTaskModel> Tasks { get; set; }
        public List<TaskLogsModel> TaskLogs { get; set; }

        //public List<ProcessUtilizationModel> ProcessUtilization { get; set; }

        public List<ProcessUtilizationModel> ProcessUtilization
        {
            get
            {
                List<ProcessUtilizationModel> list = new List<ProcessUtilizationModel>();
                foreach (var mac in this.Machines)
                {
                    ProcessUtilizationModel ivd = new ProcessUtilizationModel();
                    ivd.MachineId = mac.MachineId;
                    ivd.MachineName = mac.MachineCode;

                    var tasks = this.Tasks.Where(x => (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == mac.MachineCode).ToList();
                    ivd.PlanningTime = tasks.Sum(s => s.StandardTime);
                    ivd.AvailableTime = mac.WorkingHr * 60;
                    ivd.MachineTime = this.GetMachineTimeByTasks(tasks);
                    ivd.MaintenanceTime = 0;
                    ivd.BreakdownTime = 0;
                    ivd.SettingTime = 0;

                    list.Add(ivd);
                }

                return list;
            }
        }

        public int LoadingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.LoadingTime));
            }
        }

        public int UnLoadingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.UnLoadingTime));
            }
        }
        public int MaintenanceTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.MaintenanceTime));
            }
        }
        public int BreakdownTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.BreakdownTime));
            }
        }

        public int SettingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.SettingTime));
            }
        }

        public int MachineTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.MachineTime));
            }
        }

        public int ProductionRunTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.ProductionRunTime));
            }
        }

        public int AvailableTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.AvailableTime));
            }
        }

        //Planning Utilization
        public double AvailableTime 
        {
            get
            {
                return Machines.Sum(s => s.WorkingHr * 60);
            }
        }

        //Get Machines available time (mn)
        public double PlanningTime
        {
            get
            {
                return Tasks.Sum(s => s.StandardTime);
            }
        }
        public int PlanningTimePercentage
        {
            get
            {
                return Convert.ToInt32((((PlanningTime == 0) ? 1 : PlanningTime) / ((AvailableTime == 0) ? 1 : AvailableTime)) * 100);
            }
        }

        private double GetMachineTimeByTasks(List<JobEntityTaskModel> tasks)
        {
            double _machineTime = 0;
            foreach(var t in tasks)
            {
                DateTime startTime = DateTime.Now;
                DateTime finishTime = DateTime.Now;

                var startTask = this.TaskLogs.Where(x => x.ActionName == "START" 
                                                    && (string.IsNullOrEmpty(x.TaskEntity.MachineNoReady) ? x.TaskEntity.MachineNo : x.TaskEntity.MachineNoReady) 
                                                    == (string.IsNullOrEmpty(t.MachineNoReady) ? t.MachineNo : t.MachineNoReady)
                                                    && x.TaskId == t.TaskId).FirstOrDefault();
                var finishTask = this.TaskLogs.Where(x => x.ActionName == "MC_FINISH"
                                                    && (string.IsNullOrEmpty(x.TaskEntity.MachineNoReady) ? x.TaskEntity.MachineNo : x.TaskEntity.MachineNoReady)
                                                    == (string.IsNullOrEmpty(t.MachineNoReady) ? t.MachineNo : t.MachineNoReady)
                                                    && x.TaskId == t.TaskId).FirstOrDefault();

                if (startTask != null)
                    startTime = startTask.ActionTimeStamp;

                if(finishTask != null)
                    finishTime = finishTask.ActionTimeStamp;

                double diff = (finishTime - startTime).Minutes;
                _machineTime = _machineTime + diff;
            }
            return _machineTime;
        }
    }


    public class ProcessUtilizationModel
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public double PlanningTime { get; set; }
        public int PlanningTimePercentage
        {
            get
            {
                return Convert.ToInt32((((PlanningTime == 0) ? 1 : PlanningTime) / ((AvailableTime == 0) ? 1 : AvailableTime)) * 100);
            }
        }
        public double AvailableTime { get; set; }        
        public double ProductionRunTime 
        {
            get { return MachineTime + LoadingTime + UnLoadingTime; }
        }
        public double MachineTime { get; set; }
        public double LoadingTime
        {
            get { return MachineTime * 0.05; }
        }
        public double UnLoadingTime
        {
            get { return MachineTime * 0.05; }
        }
        public double MaintenanceTime { get; set; }
        public double BreakdownTime { get; set; }
        public double SettingTime { get; set; }
    }
}
