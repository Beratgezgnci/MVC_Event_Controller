using BE_105_Week09_Berat.Data;
using BE_105_Week09_Berat.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BE_105_Week09_Berat.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index() 
        {
            var events = _context.Events.ToList();
            ViewBag.Message = $"Veri tabanında {events.Count} adet kayıtlı etkinliğiniz vardır.";
            return View(events); 
        }
        [HttpGet]
        public IActionResult  Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventModel _event)
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(!id.HasValue)
                return RedirectToAction(nameof(Index));
            
            var _event = _context.Events.Find(id);

            if (_event == null)
                return RedirectToAction(nameof(Index));
            
            return View(_event);
        }
        [HttpPost]
        public IActionResult Edit(int? id, EventModel _event) 
        {
            _context.Events.Update(_event);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? id) 
        { 
            if(!id.HasValue)
                return RedirectToAction(nameof(Index));
            var _event = _context.Events.Find(id);
            
            if(_event == null)
                return RedirectToAction(nameof(Index));

            _context.Remove(_event);
            _context.SaveChanges();
           
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var _event = _context.Events.Find(id);

            if (_event == null)
                return RedirectToAction(nameof(Index));

            return View(_event);
        }
    }
}
