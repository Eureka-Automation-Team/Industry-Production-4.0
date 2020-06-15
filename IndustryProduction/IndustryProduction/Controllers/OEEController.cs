using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndustryProduction.Data;
using IndustryProduction.Models;
using IndustryProduction.ViewModels.OeeReport;
using IndustryProduction.ViewModels.Production;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IndustryProduction.Controllers
{
    public class OEEController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ProductionViewModel _productionViewModel;
        private OEEViewModel _oeeViewModel;

        public OEEController(ApplicationDbContext context)
        {
            _context = context;
            _productionViewModel = new ProductionViewModel();
            _oeeViewModel = new OEEViewModel();
        }

        public async Task<IActionResult> OeeReport()
        {
            List<Machine> _machines = new List<Machine>();

            _machines = await (from macs in _context.MachinesMaster
                               select macs).ToListAsync();
            ViewBag.ReadyFlag = 0;
            ViewBag.ListOfMachine = _machines;
            var machineGroup = (from p in _machines
                                group p by p.MacGroup into g
                                select new { MachineGroup = g.Key }).ToList();

            var prodLines = (from p in _machines
                             group p by p.ProductionLine into g
                             select new { ProdLine = g.Key }).ToList();
            ViewBag.ListOfMachineGroup = machineGroup;
            ViewBag.ListOfProdLine = prodLines;
            return View();
        }

        public async Task<IActionResult> IndexAsync()
        {
            _productionViewModel.StartDate = DateTime.Now;
            _productionViewModel.EndDate = DateTime.Now;
            //_productionViewModel.prodModel = string.IsNullOrEmpty(model) ? "" : model;
            _productionViewModel.Tasks = await _context.JobTasks.ToListAsync();
            // PartialView("_ProductionQueing");
            return View(_productionViewModel);
        }

        [HttpGet]
        public string GetPlanningUtilization(string startDate, string endDate, string machineNo, string machineGroup, string pdLine)
        {            
            DateTime date1 = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime date2 = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks.Include(c => c.JobEntity)
                                        .Include(c => c.Machine)
                                        .Where(x => x.StartDate.Date >= date1 && x.StartDate.Date <= date2 && x.ReleaseFlag)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();

            if (!string.IsNullOrEmpty(machineNo)) result = result.Where(x => (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo).ToList();
            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();


            // Get all machines to view-model
            _oeeViewModel.Machines = _context.MachinesMaster.ToList();

            if (string.IsNullOrEmpty(machineNo))
                _oeeViewModel.Machine = _oeeViewModel.Machines.FirstOrDefault();
            else
                _oeeViewModel.Machine = _oeeViewModel.Machines.Where(x => x.MachineCode.Trim() == machineNo.Trim()).FirstOrDefault();

            // Get tasks by condition to view-model
            _oeeViewModel.Tasks = result.ToList();
            // Get transaction logs
            _oeeViewModel.TaskLogs = _context.TaskTransactionLogs.Include(c => c.JobEntity)
                                .Include(c => c.TaskEntity)
                                .Where(x => x.TaskEntity.StartDate >= date1 && x.TaskEntity.StartDate.Date <= date2 && x.TaskEntity.ReleaseFlag)
                                .ToList();

            return (JsonConvert.SerializeObject(_oeeViewModel, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        [HttpGet]
        public string GetProcessUtilization(string startDate, string endDate, string machineNo, string machineGroup, string pdLine)
        {
            DateTime date1 = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime date2 = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks.Include(c => c.JobEntity)
                                        .Include(c => c.Machine)
                                        .Where(x => x.StartDate.Date >= date1 && x.StartDate.Date <= date2 && x.ReleaseFlag)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();

            if (!string.IsNullOrEmpty(machineNo)) result = result.Where(x => (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo).ToList();
            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            // Get transaction logs
            _oeeViewModel.TaskLogs = _context.TaskTransactionLogs.Include(c => c.JobEntity)
                                .Include(c => c.TaskEntity)
                                .Where(x => x.TaskEntity.DueDate >= date1 && x.TaskEntity.DueDate.Date <= date2 && x.TaskEntity.ReleaseFlag)
                                .ToList();
            // Get all machines to view-model
            _oeeViewModel.Machines = _context.MachinesMaster.Include(c => c.WorkingTime).ToList();

            if (string.IsNullOrEmpty(machineNo))
                _oeeViewModel.Machine = _oeeViewModel.Machines.FirstOrDefault();
            else
                _oeeViewModel.Machine = _oeeViewModel.Machines.Where(x => x.MachineCode.Trim() == machineNo.Trim()).FirstOrDefault();

            // Get tasks by condition to view-model
            _oeeViewModel.Tasks = result.ToList();

            return (JsonConvert.SerializeObject(_oeeViewModel, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }


        [HttpGet]
        public string GetOEEReportByMachine(string startDate, string endDate, string machineNo, string machineGroup, string pdLine)
        {
            OeeReportModel _result = new OeeReportModel();            

            DateTime start = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime end = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;
            
            _result.Machine = _context.MachinesMaster
                                    .Where(x => x.MachineCode.Equals(machineNo))
                                    .Include(c => c.WorkingTime)
                                    .FirstOrDefault();
            _result.MachineWorking = _context.MachineWorkings
                                            .Where(x => x.MachineId == _result.Machine.Id)
                                            .Include(c => c.Shift).ToList();

            var result = _context.JobTasks.Include(c => c.JobEntity)
                                        .Include(c => c.Machine)
                                        .Where(x => x.StartDate.Date >= start 
                                                && x.StartDate.Date <= end 
                                                && x.ReleaseFlag
                                                && (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();            

            machineGroup = machineGroup.Replace("- Optional -", string.Empty);
            pdLine = pdLine.Replace("- Optional -", string.Empty);

            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            _result.TasksAll = result;
            if (result != null)
            {
                _result.PlanningTimeMin = result.Sum(x => x.StandardTime);
                _result.AvailableTimeMin = _result.MachineWorking.Sum(x => x.Shift.WorkingMin);
                _result.ProductionTimeMin = result.Where(x => x.McFinishFlag).Sum(x => x.StandardTime);

                _result.MachineTimeMin = 0;
                _result.LoadingTimeHr = 0;
                _result.UnloadingimeHr = 0;
                _result.MaintenanceTimeHr = 0;
                _result.BreakdownTimeHr = 0;
                _result.SettingTimeHr = 0;

                _result.PlanninPcs = Convert.ToInt32(result.Sum(s => s.PrimaryQuantity));
                _result.Actual = Convert.ToInt32(result.Where(x => x.McFinishFlag).Sum(s => s.PrimaryQuantity));
                _result.QcPass = Convert.ToInt32(result.Where(x => x.QCStatus == "PASS").Sum(s => s.PrimaryQuantity));
                _result.QcNG = Convert.ToInt32(result.Where(x => x.QCStatus == "NG").Sum(s => s.PrimaryQuantity));
                _result.Hold = Convert.ToInt32(result.Where(x => x.QCStatus == "NONE").Sum(s => s.PrimaryQuantity));
                _result.Reject = _result.QcNG;
                _result.Rework = 0;

                for(int i=0; i<1; i++)
                {
                    OEELineModel line = new OEELineModel();
                    line.MachineCode = _result.Machine.MachineCode;
                    line.AvailableTimeHr = _result.AvailableTimeHr;
                    line.PlanningTimeHr = _result.PlanningTimeHr;
                    line.ProductionTimeHr = _result.ProductionTimeHr;
                    line.PlanUtilization = _result.PlanningUtilization;
                    line.ProcessUtilization = _result.ProcessUtilization;
                    line.Actual = _result.Actual;
                    line.PlanninPcs = _result.PlanninPcs;
                    line.Reject = _result.Reject;
                    line.Rework = _result.Rework;
                    line.Performance = Math.Round(_result.Performance, 2);
                    line.Quality = _result.Quality;
                    line.OEE = _result.OEE;
                    line.QcPass = _result.QcPass;
                    line.QcNG = _result.QcNG;
                    line.Hold = _result.Hold;

                    _result.OeeLine.Add(line);
                }

            }

            return (JsonConvert.SerializeObject(_result, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }


    }
}