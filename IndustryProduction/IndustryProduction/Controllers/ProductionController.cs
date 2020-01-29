using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryProduction.Data;
using IndustryProduction.Models;
using IndustryProduction.ViewModels.Production;
using Newtonsoft.Json;

namespace IndustryProduction.Controllers
{
    public class ProductionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ProductionViewModel _productionViewModel;

        public ProductionController(ApplicationDbContext context)
        {
            _context = context;
            _productionViewModel = new ProductionViewModel();
        }

        // GET: Production
        public async Task<IActionResult> Index()
        {
            _productionViewModel.StartDate = DateTime.Now;
            _productionViewModel.EndDate = DateTime.Now;
            //_productionViewModel.prodModel = string.IsNullOrEmpty(model) ? "" : model;
            _productionViewModel.Tasks = await _context.JobTasks.ToListAsync();
            //PartialView("_ProductionQueing");
            return View(_productionViewModel);
        }

        public IActionResult ProductionQueing()
        {
            _productionViewModel.Tasks = _context.JobTasks
                                        .Where(x => x.StartDate.Date >= DateTime.Now.Date)
                                        .Where(x => x.StartDate.Date <= DateTime.Now.Date)
                                        .ToList();

            return PartialView("_ProductionQueing", _productionViewModel);
        }

        [HttpGet]
        public string GetTaskQueing(string startDate, string endDate, string machineNo, string machineGroup, string machineModel, string pdLine)
        {
            DateTime date1 = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime date2 = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks.Include(c => c.JobEntity)
                                        .Include(c => c.Machine)
                                        .Where(x => x.DueDate.Date >= date1 && x.DueDate.Date <= date2 && x.ReleaseFlag && !x.McFinishFlag)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();

            if (!string.IsNullOrEmpty(machineNo)) result = result.Where(x => x.MachineNoReady == machineNo).ToList();
            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(machineModel)) result = result.Where(x => x.Machine.MacModel == machineModel).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            return (JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        [HttpGet]
        public string GetTaskProductionRecord(string startDate, string endDate, string machineNo, string machineGroup, string machineModel, string pdLine)
        {
            DateTime date1 = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime date2 = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks.Include(c => c.JobEntity)
                                        .Include(c => c.Machine)
                                        .Where(x => x.DueDate.Date >= date1 && x.DueDate.Date <= date2 && x.ReleaseFlag && x.McFinishFlag)
                                        .OrderBy(o => o.Priority)
                                        .ThenBy(o => o.StartDate)
                                        .ToList();

            if (!string.IsNullOrEmpty(machineNo)) result = result.Where(x => x.MachineNoReady == machineNo).ToList();
            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(machineModel)) result = result.Where(x => x.Machine.MacModel == machineModel).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            return (JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        // GET: Production/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntityTaskModel = await _context.JobTasks
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (jobEntityTaskModel == null)
            {
                return NotFound();
            }

            return View(jobEntityTaskModel);
        }

        // GET: Production/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Production/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskSeq,JobEntityId,TaskNumber,JobNumber,Description,Manager,StartDate,EndDate,CancelFlag,LastUpdateDate,LastUpdatedBy,CreationDate,CreatedBy,ErrorText,ReadyFlag,ReleaseFlag,UploadNcfileFlag,TransferNCFileToMachineFlag,TransferMessage,Source,ShelfNumber,ReserveShelfFlag,OnShelfFlag,McProcessFlag,McPickFlag,McLoadFlag,McFinishFlag,McUnloadFlag,McPushFlag,OutboundFlag,OutboundFinishFlag,QCStatus,MaterialCode,TableNumber,NcFile,DueDate,MachineNo,MachineNoReady,Priority,StandardTime,PrimaryItemCode,PrimaryItemModel,PrimaryQuantity,StartFlag")] JobEntityTaskModel jobEntityTaskModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobEntityTaskModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntityTaskModel);
        }

        // GET: Production/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntityTaskModel = await _context.JobTasks.FindAsync(id);
            if (jobEntityTaskModel == null)
            {
                return NotFound();
            }
            return View(jobEntityTaskModel);
        }

        // POST: Production/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskSeq,JobEntityId,TaskNumber,JobNumber,Description,Manager,StartDate,EndDate,CancelFlag,LastUpdateDate,LastUpdatedBy,CreationDate,CreatedBy,ErrorText,ReadyFlag,ReleaseFlag,UploadNcfileFlag,TransferNCFileToMachineFlag,TransferMessage,Source,ShelfNumber,ReserveShelfFlag,OnShelfFlag,McProcessFlag,McPickFlag,McLoadFlag,McFinishFlag,McUnloadFlag,McPushFlag,OutboundFlag,OutboundFinishFlag,QCStatus,MaterialCode,TableNumber,NcFile,DueDate,MachineNo,MachineNoReady,Priority,StandardTime,PrimaryItemCode,PrimaryItemModel,PrimaryQuantity,StartFlag")] JobEntityTaskModel jobEntityTaskModel)
        {
            if (id != jobEntityTaskModel.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobEntityTaskModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobEntityTaskModelExists(jobEntityTaskModel.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntityTaskModel);
        }

        // GET: Production/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntityTaskModel = await _context.JobTasks
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (jobEntityTaskModel == null)
            {
                return NotFound();
            }

            return View(jobEntityTaskModel);
        }

        // POST: Production/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobEntityTaskModel = await _context.JobTasks.FindAsync(id);
            _context.JobTasks.Remove(jobEntityTaskModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobEntityTaskModelExists(int id)
        {
            return _context.JobTasks.Any(e => e.TaskId == id);
        }
    }
}
