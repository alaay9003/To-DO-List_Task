using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using To_DO_List_Task.Data;
using To_DO_List_Task.Models;

namespace To_DO_List_Task.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var notes = await _context.Notes.ToListAsync();
            return View(notes);
        }
        public ActionResult AddNote()
        {
            return View("NoteForm");
        }
        public async Task<IActionResult> Add(Note note)
        {
            if(note.Content==null)
            {
                return View("NoteForm",note);
            }
            if (note.Id == 0)
            {
                var item = new Note
                {
                    Content = note.Content,
                    ExpectedTime = note.ExpectedTime,
                    AddTime=DateTime.Now,
                };
                await _context.Notes.AddAsync(item);
            }
            else
            {
                var item = new Note
                {
                    Id = note.Id,
                    Content = note.Content,
                    ExpectedTime = note.ExpectedTime,
                    AddTime = note.AddTime
                };
                _context.Notes.Update(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> delete(int id)
        {
            var item = await _context.Notes.FindAsync(id);
            if (item == null)
            {
                return BadRequest();
            }
            _context.Notes.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> update(int id)
        {
            var item = await _context.Notes.FindAsync(id);
            if (item == null)
            {
                return BadRequest();
            }
            return View("NoteForm",item);
        }
    }
}
