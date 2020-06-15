using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryProduction.Data;
using IndustryProduction.Models;
using System.Net.Http;
using System.Diagnostics;
using System.IO;

namespace IndustryProduction.Controllers
{
    public class CameraSettingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private HttpClient _client;

        public CameraSettingController(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        // GET: CameraSetting
        public async Task<IActionResult> Index()
        {
            return View(await _context.CameraSetting.ToListAsync());
        }

        // GET: CameraSetting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cameraSettingModel = await _context.CameraSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraSettingModel == null)
            {
                return NotFound();
            }

            return View(cameraSettingModel);
        }

        // GET: CameraSetting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CameraSetting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CameraCode,CameraUrl,Port,Username,Password,Id")] CameraSettingModel cameraSettingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cameraSettingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cameraSettingModel);
        }

        // GET: CameraSetting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cameraSettingModel = await _context.CameraSetting.FindAsync(id);
            if (cameraSettingModel == null)
            {
                return NotFound();
            }
            return View(cameraSettingModel);
        }

        // POST: CameraSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CameraCode,CameraUrl,Port,Username,Password,Id")] CameraSettingModel cameraSettingModel)
        {
            if (id != cameraSettingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cameraSettingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CameraSettingModelExists(cameraSettingModel.Id))
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
            return View(cameraSettingModel);
        }

        // GET: CameraSetting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cameraSettingModel = await _context.CameraSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cameraSettingModel == null)
            {
                return NotFound();
            }

            return View(cameraSettingModel);
        }

        // POST: CameraSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cameraSettingModel = await _context.CameraSetting.FindAsync(id);
            _context.CameraSetting.Remove(cameraSettingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CameraSettingModelExists(int id)
        {
            return _context.CameraSetting.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Monitor()
        {
            CameraSettingModel camera = new CameraSettingModel();

            camera = await (from macs in _context.CameraSetting
                               select macs).FirstOrDefaultAsync();

            ViewBag.CameraCode = camera.CameraCode;
            ViewBag.CameraUrl = camera.CameraUrl;
            ViewBag.CameraPort = camera.Port;

            return View();
        }

        public async Task<Stream> GetIpCameraAsync()
        {
            var urlBlob = @"rtsp://admin:admin@192.168.4.98:88/live/video/profile2";            
            return await _client.GetStreamAsync(urlBlob);
        }


        [HttpGet()]
        public async Task<FileStreamResult> GetStream()
        {
            var stream = await GetIpCameraAsync();
            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
