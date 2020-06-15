using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IndustryProduction.Data;
using IndustryProduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace IndustryProduction.Controllers
{
    public class ProductionStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
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

        [HttpGet]
        public string GetProgressionAsync(string startDate, string endDate, string machineNo, string machineGroup, string machineModel, string pdLine)
        {
            ProductionProgressModel progression = new ProductionProgressModel();

            progression.StartTime = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            progression.EndTime = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            Machine machine = new Machine();

            //Get Machine Master and Working Shifts
            machine = _context.MachinesMaster.Include(c => c.WorkingTime)
                                             .Where(x => x.MachineCode.Equals(machineNo))
                                             .FirstOrDefault();
            //Machine is available
            if(machine != null)
            {                
                progression.MachineCode = machine.MachineCode;
                int days = Convert.ToInt32((progression.EndTime - progression.StartTime).TotalDays);

                for(int i = 0; i <= days; i++)
                {
                    WorkingDay wkDay = new WorkingDay();
                    wkDay.WorkDate = progression.StartTime.AddDays(i);
                    foreach(var item in machine.WorkingTime.OrderBy(o => o.ShiftId))
                    {
                        WorkingShift shift = _context.WorkingShifts.Where(x => x.Id == item.ShiftId).FirstOrDefault();
                        ShiftsDay wkShift = new ShiftsDay();
                        int dayTotal = Convert.ToInt32((wkDay.WorkDate.Date - shift.StartTime.Date).TotalDays);

                        wkShift.ShiftId = shift.Id;
                        wkShift.StartTime = shift.StartTime.AddDays(dayTotal);
                        wkShift.EndTime = shift.EndTime.AddDays(dayTotal); 
                        wkShift.TasksCount = _context.JobTasks
                                            .Where(x => x.MachineNo.Equals(machineNo) &&
                                                        x.StartDate >= progression.StartTime && x.StartDate <= progression.EndTime).Count();
                        wkDay.ShiftTasks.Add(wkShift);
                    }

                    wkDay.StartDate = wkDay.ShiftTasks.OrderBy(o => o.StartTime).FirstOrDefault().StartTime;
                    wkDay.EndDate = wkDay.ShiftTasks.OrderByDescending(o => o.EndTime).FirstOrDefault().EndTime;
                    progression.WorkingDays.Add(wkDay);
                }
            }

            return (JsonConvert.SerializeObject(progression, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        [HttpGet]
        public string GetTaskSummary(string startDate, string endDate, string machineNo, string machineGroup, string machineModel, string pdLine)
        {
            TaskSummary summary = new TaskSummary();

            summary.StartTime = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            summary.EndTime = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks.Include(c => c.JobEntity)
                            .Include(c => c.Machine)
                            .Include(c => c.JobEntity)
                            .Where(x => x.StartDate.Date >= summary.StartTime.Date
                                    && x.StartDate.Date <= summary.EndTime.Date
                                    && x.ReleaseFlag
                                    && (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo)
                            .OrderBy(o => o.Priority)
                            .ThenBy(o => o.StartDate)
                            .ToList();

            machineGroup = machineGroup.Replace("- Optional -",string.Empty);
            pdLine = pdLine.Replace("- Optional -", string.Empty);

            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(machineModel)) result = result.Where(x => x.Machine.MachineModel == machineModel).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            //Summaries
            summary.TasksAll = result;

            int i = 1;
            foreach(var item in summary.TasksAll.Where(x => !x.McFinishFlag && !x.CancelFlag).OrderBy(o => o.Priority).ToList())
            {
                TasksQueuing task = new TasksQueuing();
                task.Seq = i;
                task.PartNumber = item.JobEntity.PrimaryItemCode;
                task.MachineCode = item.Machine.MachineCode;
                task.JobNumber = item.JobEntity.JobEntityName;
                task.TableNumber = item.TableNumber;
                task.DueDate = item.DueDate;
                task.RequiredDate = item.EndDate.ToString("dd/MM/yyyy HH:mm");
                if (item.StartFlag)
                    task.ProductionStatus = "Inprogress";
                else
                    task.ProductionStatus = "Pending";

                summary.TasksQueuing.Add(task);
                i++;
            }

            foreach (var item in summary.TasksAll.Where(x => x.StartFlag && x.McFinishFlag && !x.CancelFlag).OrderBy(o => o.DueDate).ToList())
            {
                ProductionRecord rec = new ProductionRecord();
                rec.PartNumber = item.JobEntity.PrimaryItemCode;
                rec.MachineNo = item.Machine.MachineCode;
                rec.JobNumber = item.JobEntity.JobEntityName;
                rec.TableNumber = item.TableNumber;
                rec.DueDate = item.DueDate;
                rec.NcFile = item.NcFile;

                var logs = _context.TaskTransactionLogs.Where(x => x.TaskId == item.Id).ToList();
                DateTime startTime = logs.Where(x => x.ActionName == "START").FirstOrDefault().ActionTimeStamp;
                DateTime finishTime = logs.Where(x => x.ActionName == "MC_FINISH").FirstOrDefault().ActionTimeStamp;

                rec.StartTime = startTime.ToString("dd/MM/yyyy HH:mm");
                rec.FinishTime = finishTime.ToString("dd/MM/yyyy HH:mm");
                rec.MachineTimeHr = (finishTime - startTime).TotalHours.ToString("#0.00"); 

                summary.TasksRecord.Add(rec);
                i++;
            }

            return (JsonConvert.SerializeObject(summary, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        [HttpGet]
        public string GetProgressionBar(string startDate, string endDate, string machineNo, string machineGroup, string machineModel, string pdLine)
        {
            List<ProductionProgressModel> progressions = new List<ProductionProgressModel>();
            Machine machine = new Machine();
            machine = _context.MachinesMaster.Include(c => c.WorkingTime)
                                             .Where(x => x.MachineCode.Equals(machineNo))
                                             .FirstOrDefault();
            

            DateTime startTime = string.IsNullOrEmpty(startDate) ? DateTime.Now.Date : Convert.ToDateTime(startDate).Date;
            DateTime endTime = string.IsNullOrEmpty(endDate) ? DateTime.Now.Date : Convert.ToDateTime(endDate).Date;

            var result = _context.JobTasks
                            .Where(x => x.StartDate.Date >= startTime
                                    && x.StartDate.Date <= endTime
                                    && x.ReleaseFlag
                                    && (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == machineNo)
                            .Include(c => c.Machine)
                            .Include(c => c.JobEntity)
                            .OrderBy(o => o.Priority)
                            .ThenBy(o => o.StartDate)
                            .ToList();

            machineGroup = machineGroup.Replace("- Optional -", string.Empty);
            pdLine = pdLine.Replace("- Optional -", string.Empty);

            if (!string.IsNullOrEmpty(machineGroup)) result = result.Where(x => x.Machine.MacGroup == machineGroup).ToList();
            if (!string.IsNullOrEmpty(machineModel)) result = result.Where(x => x.Machine.MachineModel == machineModel).ToList();
            if (!string.IsNullOrEmpty(pdLine)) result = result.Where(x => x.Machine.ProductionLine == pdLine).ToList();

            int days = Convert.ToInt32((endTime - startTime).TotalDays);
            DateTime currentDate = DateTime.Now.Date;
            for (int i = 0; i <= days; i++)
            {
                ProductionProgressModel prog = new ProductionProgressModel();
                DateTime aDay = startTime.AddDays(i);

                prog.Alarms = _context.AlarmHistories
                                    .Where(x => x.StartTime.Date == startTime
                                           && x.MachineId == machine.Id).ToList();

                //prog.Alarms = _context.AlarmHistories
                //    .Where(x => x.MachineId == machine.Id).Take(2).ToList();
                prog.TaskStartTime = 0;
                prog.AvailableTime = 24;  //Fixed 24hr.
                if (aDay.Date > currentDate)
                    prog.TimeProgress = 0;
                else if (aDay.Date < currentDate)
                    prog.TimeProgress = 24;
                else
                    prog.TimeProgress = Convert.ToDouble(DateTime.Now.Hour.ToString() + "." +((DateTime.Now.Minute * 100)/60).ToString());

                if(result.Count != 0)
                {
                    try
                    {
                        prog.StartTime = result.Where(x => x.StartDate.Date == aDay.Date).OrderBy(o => o.StartDate).FirstOrDefault().StartDate;
                        prog.EndTime = result.Where(x => x.StartDate.Date == aDay.Date).OrderByDescending(o => o.EndDate).FirstOrDefault().EndDate;
                        prog.TaskStartTime = prog.StartTime.Hour;
                        prog.TaskEndTime = prog.EndTime.Hour;
                    }
                    catch{
                        prog.StartTime = aDay;
                        prog.EndTime = aDay;
                    }
                }
                prog.PlanVsAvailable = (prog.EndTime - prog.StartTime).TotalHours;

                double productionTime = 0;
                foreach (var item in result.Where(x => x.StartDate.Date == aDay.Date 
                                                && x.StartFlag 
                                                && x.McFinishFlag 
                                                && !x.CancelFlag)
                                            .OrderBy(o => o.DueDate).ToList())
                {
                    var logs = _context.TaskTransactionLogs.Where(x => x.TaskId == item.Id).ToList();
                    DateTime start = logs.Where(x => x.ActionName == "START").FirstOrDefault().ActionTimeStamp;
                    DateTime finish = logs.Where(x => x.ActionName == "MC_FINISH").FirstOrDefault().ActionTimeStamp;
                    productionTime = productionTime + ((finish - start).TotalHours);
                }
                prog.ProductionProgress = productionTime;

                progressions.Add(prog);
            }

            return (JsonConvert.SerializeObject(progressions, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }));
        }

        //[HttpGet]
        public FileStreamResult ViewStream()
        {
            // Your validation logic here
            
            //RtspClient Rtsp;
            //Rtsp.RtspServer server = new Rtsp.RtspServer(/*554*/);
            var source = "https://youtu.be/2apvV2F0n8Y";
            var req = HttpWebRequest.Create(source);
            var resp = req.GetResponse();

            return new FileStreamResult(resp.GetResponseStream(), resp.ContentType);
        }

        [HttpPost]
        public IActionResult LaunchExternalProcess()
        {
            var p = new Process();

            //var process = Process.Start(@"C:\Program Files(x86)\RWS\Setup\IndustrialNetworks.CameraDemo.exe ""rtsp://admin:admin@192.168.4.98:88/live/video/profile2""");
            //var process = Process.Start(@"C:\Program Files(x86)\RWS\Setup\IndustrialNetworks.CameraDemo.exe");
            //var process = Process.Start(@"C:\Program Files\Eureka Automation Company Limited\Eureka Automation System\Eureka.Forms.exe");
            string _path = Directory.GetCurrentDirectory();
            p.StartInfo.FileName = string.Format(@"C:\Program Files\Eureka Automation Company Limited\Eureka Automation System\Eureka.Forms.exe", _path);
            //p.StartInfo.FileName = @"C:\Program Files\EurekaCamera\IndustrialNetworks.CameraDemo.exe";
            //p.StartInfo.FileName = @"C:\Program Files\Eureka Automation Company Limited\Eureka Automation System\Eureka.Forms.exe";
            p.StartInfo.Arguments = "/c echo rtsp://admin:admin@192.168.4.98:88/live/video/profile2";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            if (p == null) // failed to start
            {
                return NotFound();
            }
            else // Started, wait for it to finish
            {
                //p.WaitForExit();
                return Ok();
            }
        }
    }
}