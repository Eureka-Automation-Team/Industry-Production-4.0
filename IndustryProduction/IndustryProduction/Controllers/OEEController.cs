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
                                        .Where(x => x.DueDate.Date >= date1 && x.DueDate.Date <= date2 && x.ReleaseFlag)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();

            if (!string.IsNullOrEmpty(machineNo)) result = result.Where(x => (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo).ToList();
            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();


            // Get all machines to view-model
            _oeeViewModel.Machines = _context.Machines.ToList();
            // Get tasks by condition to view-model
            _oeeViewModel.Tasks = result.ToList();
            // Get transaction logs
            _oeeViewModel.TaskLogs = _context.TaskTransactionLogs.Include(c => c.JobEntity)
                                .Include(c => c.TaskEntity)
                                .Where(x => x.TaskEntity.DueDate >= date1 && x.TaskEntity.DueDate.Date <= date2 && x.TaskEntity.ReleaseFlag)
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
                                        .Where(x => x.DueDate.Date >= date1 && x.DueDate.Date <= date2 && x.ReleaseFlag)
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
            _oeeViewModel.Machines = _context.Machines.ToList();
            // Get tasks by condition to view-model
            _oeeViewModel.Tasks = result.ToList();

            return (JsonConvert.SerializeObject(_oeeViewModel, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }


    }
}