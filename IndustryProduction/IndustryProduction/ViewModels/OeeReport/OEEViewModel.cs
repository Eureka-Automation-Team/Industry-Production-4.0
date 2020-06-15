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
        public List<Machine> Machines { get; set; }
        public List<JobEntityTaskModel> Tasks { get; set; }
        public List<TaskLogsModel> TaskLogs { get; set; }

        public Machine Machine { get; set; }

        public List<ProcessUtilizationModel> Productivities 
        {
            get { return ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).ToList(); }
        }

        public List<ProcessUtilizationModel> ProcessUtilization
        {
            get
            {
                List<ProcessUtilizationModel> list = new List<ProcessUtilizationModel>();
                foreach (var mac in this.Machines)
                {
                    ProcessUtilizationModel ivd = new ProcessUtilizationModel();
                    ivd.MachineId = mac.Id;
                    ivd.MachineName = mac.MachineCode;

                    var tasks = this.Tasks.Where(x => (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == mac.MachineCode).ToList();
                    double minuteTime = tasks.Sum(s => s.StandardTime);
                    //TimeSpan spWorkMin = TimeSpan.FromMinutes(minuteTime);

                    ivd.PlanningTime =  minuteTime;
                    ivd.AvailableTime = 16 * 60; 
                    //var workingTimeHr = 
                    //Production running time
                    //ivd.MachineTime = this.GetMachineProductionTimeByTasks(tasks);

                    //Planning time
                    ivd.MachineTime = this.GetMachinePlanningTimeByTasks(tasks);

                    ivd.MaintenanceTime = 0;
                    ivd.BreakdownTime = 0;
                    ivd.SettingTime = 0;

                    ivd.PlanQuantity = this.GetPlanQuantityByTasks(tasks);
                    ivd.ActualQuantity = this.GetActualQuantityByTasks(tasks);

                    ivd.PassQuantity = this.GetPassQuantityByTasks(tasks); ;
                    ivd.NgQuantity = this.GetNGQuantityByTasks(tasks);
                    ivd.HoldQuantity = this.GetHoldQuantityByTasks(tasks);
                    ivd.RejectQuantity = ivd.NgQuantity;
                    ivd.ReworkQuantity = 0;

                    list.Add(ivd);
                }

                return list;
            }
        }

        private int GetHoldQuantityByTasks(List<JobEntityTaskModel> tasks)
        {
            int _quantity = 0;
            _quantity = Convert.ToInt32(tasks.Where(x => x.ReleaseFlag && x.StartFlag && x.McFinishFlag && x.QCStatus == "NONE").Sum(s => s.PrimaryQuantity));

            return _quantity;
        }

        private int GetNGQuantityByTasks(List<JobEntityTaskModel> tasks)
        {
            int _quantity = 0;
            _quantity = Convert.ToInt32(tasks.Where(x => x.ReleaseFlag && x.StartFlag && x.McFinishFlag && x.QCStatus == "NG").Sum(s => s.PrimaryQuantity));

            return _quantity;
        }

        private int GetPassQuantityByTasks(List<JobEntityTaskModel> tasks)
        {
            int _quantity = 0;
            _quantity = Convert.ToInt32(tasks.Where(x => x.ReleaseFlag && x.StartFlag && x.McFinishFlag && x.QCStatus == "PASS").Sum(s => s.PrimaryQuantity));

            return _quantity;
        }

        private int GetActualQuantityByTasks(List<JobEntityTaskModel> tasks)
        {
            int _quantity = 0;
            _quantity = Convert.ToInt32(tasks.Where(x => x.ReleaseFlag && x.StartFlag && x.McFinishFlag).Sum(s => s.PrimaryQuantity));

            return _quantity;
        }

        private int GetPlanQuantityByTasks(List<JobEntityTaskModel> tasks)
        {
            int _quantity = 0;
            _quantity = tasks.Where(x => x.ReleaseFlag).Count();
            
            return _quantity;
        }

        public int LoadingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.LoadingTime));
            }
        }
        public double LoadingTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(LoadingTimeSummary) / 60;
                int Minute = Convert.ToInt32(LoadingTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        public int UnLoadingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.UnLoadingTime));
            }
        }
        public double UnLoadingTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(UnLoadingTimeSummary) / 60;
                int Minute = Convert.ToInt32(UnLoadingTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public int MaintenanceTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.MaintenanceTime));
            }
        }
        public double MaintenanceTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(MaintenanceTimeSummary) / 60;
                int Minute = Convert.ToInt32(MaintenanceTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public int BreakdownTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.BreakdownTime));
            }
        }
        public double BreakdownTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(BreakdownTimeSummary) / 60;
                int Minute = Convert.ToInt32(BreakdownTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        public int SettingTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Sum(s => s.SettingTime));
            }
        }
        public double SettingTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(SettingTimeSummary) / 60;
                int Minute = Convert.ToInt32(SettingTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        public int MachineTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.MachineTime));
            }
        }
        public double MachineTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(MachineTimeSummary) / 60;
                int Minute = Convert.ToInt32(MachineTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        public int ProductionRunTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.ProductionRunTime));
            }
        }
        public double ProductionRunTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(ProductionRunTimeSummary) / 60;
                int Minute = Convert.ToInt32(ProductionRunTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }


        public int AvailableTimeSummary
        {
            get
            {
                return Convert.ToInt32(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.AvailableTime));
            }
        }
        public double AvailableTimeSummaryHr
        {
            get
            {
                int Hour = Convert.ToInt32(AvailableTimeSummary) / 60;
                int Minute = Convert.ToInt32(AvailableTimeSummary) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        //Planning Utilization
        public double AvailableTime 
        {
            get
            {
                //return Machines.Where(x => x.MachineCode == Machine.MachineCode).Sum(s => s.WorkingHr * 60);
                return 16 * 60;
            }
        }
        public double AvailableTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(AvailableTime) / 60;
                int Minute = Convert.ToInt32(AvailableTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
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
        public double PlanningTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(PlanningTime) / 60;
                int Minute = Convert.ToInt32(PlanningTime) % 60;
                return Convert.ToDouble(Hour.ToString() +"."+Minute.ToString("00"));
            }
        }
        public int PlanningTimePercentage
        {
            get
            {
                return Convert.ToInt32((((PlanningTime == 0) ? 1 : PlanningTime) / ((AvailableTime == 0) ? 1 : AvailableTime)) * 100);
            }
        }

        public double OEESummary
        { 
            get
            {
                //return Math.Round(((QualitySummary * ProductivitySummary * ProcessUtilizationSummary) / 100) / 100, 3);
                return Math.Round(((QualitySummary * ProductivitySummary * ProcessUtilizationSummary) / 100) / 100, 3);
            }
        }

        public double ProcessUtilizationSummary
        {
            get
            {
                return Math.Round((ProductionRunTimeSummaryHr / AvailableTimeHr) * 100, 2);
            }
        }

        public double ProductivitySummary
        {
            get
            {
                return ((ActualSummary == 0 ? 1 : ActualSummary) / PlanSummary) * 100;
            }
        }

        public double QualitySummary
        {
            get
            {
                return Math.Round((((RejectSummary + ReworkSummary) == 0 ? 1 : (RejectSummary + ReworkSummary) / ActualSummary)) * 100, 2);
            }
        }
        public double PlanSummary
        {
            get
            {
                return Math.Round(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.PlanQuantity), 0);
            }
        }
        public double ActualSummary
        {
            get
            {
                return Math.Round(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.ActualQuantity), 0);
            }
        }

        public double RejectSummary
        {
            get
            {
                return Math.Round(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.RejectQuantity), 2);
            }
        }

        public double ReworkSummary
        {
            get
            {
                return Math.Round(ProcessUtilization.Where(x => x.MachineName == Machine.MachineCode).Sum(s => s.ReworkQuantity), 2);
            }
        }

        private double GetMachineProductionTimeByTasks(List<JobEntityTaskModel> tasks)
        {
            double _machineTime = 0;
            foreach(var t in tasks)
            {
                DateTime startTime = DateTime.Now;
                DateTime finishTime = DateTime.Now;

                var startTask = this.TaskLogs.Where(x => x.ActionName == "START" 
                                                    && (string.IsNullOrEmpty(x.TaskEntity.MachineNoReady) ? x.TaskEntity.MachineNo : x.TaskEntity.MachineNoReady) 
                                                    == (string.IsNullOrEmpty(t.MachineNoReady) ? t.MachineNo : t.MachineNoReady)
                                                    && x.TaskId == t.Id).FirstOrDefault();
                var finishTask = this.TaskLogs.Where(x => x.ActionName == "MC_FINISH"
                                                    && (string.IsNullOrEmpty(x.TaskEntity.MachineNoReady) ? x.TaskEntity.MachineNo : x.TaskEntity.MachineNoReady)
                                                    == (string.IsNullOrEmpty(t.MachineNoReady) ? t.MachineNo : t.MachineNoReady)
                                                    && x.TaskId == t.Id).FirstOrDefault();

                if (startTask != null)
                    startTime = startTask.ActionTimeStamp;

                if(finishTask != null)
                    finishTime = finishTask.ActionTimeStamp;

                double diff = (finishTime - startTime).Minutes;
                _machineTime = _machineTime + diff;
            }
            return _machineTime;
        }

        private double GetMachinePlanningTimeByTasks(List<JobEntityTaskModel> tasks)
        {
            double _machineTime = 0;
            foreach (var t in tasks)
            {
                DateTime startTime = DateTime.Now;
                DateTime finishTime = DateTime.Now;
                /*
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

                if (finishTask != null)
                    finishTime = finishTask.ActionTimeStamp;
                */
                double diff = (t.EndDate - t.StartDate).Minutes;
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
        public double PlanningTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(PlanningTime) / 60;
                int Minute = Convert.ToInt32(PlanningTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public int PlanningTimePercentage
        {
            get
            {
                return Convert.ToInt32((((PlanningTime == 0) ? 1 : PlanningTime) / ((AvailableTime == 0) ? 1 : AvailableTime)) * 100);
            }
        }
        public double AvailableTime { get; set; }
        public double AvailableTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(AvailableTime) / 60;
                int Minute = Convert.ToInt32(AvailableTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double ProductionRunTime 
        {
            get { return MachineTime + LoadingTime + UnLoadingTime; }
        }
        public double ProductionRunTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(ProductionRunTime) / 60;
                int Minute = Convert.ToInt32(ProductionRunTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double MachineTime { get; set; }
        public double MachineTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(MachineTime) / 60;
                int Minute = Convert.ToInt32(MachineTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double LoadingTime
        {
            get { return MachineTime * 0.05; }
        }
        public double LoadingTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(LoadingTime) / 60;
                int Minute = Convert.ToInt32(LoadingTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double UnLoadingTime
        {
            get { return MachineTime * 0.05; }
        }
        public double UnLoadingTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(UnLoadingTime) / 60;
                int Minute = Convert.ToInt32(UnLoadingTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double MaintenanceTime { get; set; }
        public double MaintenanceTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(MaintenanceTime) / 60;
                int Minute = Convert.ToInt32(MaintenanceTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double BreakdownTime { get; set; }
        public double BreakdownTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(BreakdownTime) / 60;
                int Minute = Convert.ToInt32(BreakdownTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }
        public double SettingTime { get; set; }
        public double SettingTimeHr
        {
            get
            {
                int Hour = Convert.ToInt32(SettingTime) / 60;
                int Minute = Convert.ToInt32(SettingTime) % 60;
                return Convert.ToDouble(Hour.ToString() + "." + Minute.ToString("00"));
            }
        }

        public double ProcessUtilization 
        {
            get 
            {
                return Math.Round((ProductionRunTimeHr / AvailableTimeHr) * 100, 2);
            }
        }

        public double PlanQuantity { get; set; }
        public double ActualQuantity { get; set; }
        public double RejectQuantity { get; set; }
        public double ReworkQuantity { get; set; }
        public double Quality 
        {
            get
            {
                return Math.Round((((RejectQuantity + ReworkQuantity) == 0 ? 1 : (RejectQuantity + ReworkQuantity) / ActualQuantity))*100, 2);
            }
        }
        public double Productivity
        {
            get
            {
                return (ActualQuantity / PlanQuantity) * 100;
            }
        }
        public double OEE
        {
            get
            {
                return Math.Round(((Quality * Productivity * ProcessUtilization)/100)/100,3);
            }
        }

        public int PassQuantity { get; set; }
        public int NgQuantity { get; set; }
        public int HoldQuantity { get; set; }
    }

}
