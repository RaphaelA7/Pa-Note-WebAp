using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApplication5.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        [BindProperty]
        public Note NewNote { get; set; } = new Note();

        [BindProperty]
        public int EditNoteId { get; set; }

        [BindProperty]
        public int DeleteNoteId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Notes = await _context.Notes.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Notes = await _context.Notes.ToListAsync();
                return Page();
            }

            NewNote.CreatedAt = DateTime.Now;
            _context.Notes.Add(NewNote);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            var note = await _context.Notes.FindAsync(EditNoteId);
            if (note == null) return RedirectToPage();

            NewNote = note;
            Notes = await _context.Notes.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                Notes = await _context.Notes.ToListAsync();
                return Page();
            }

            var existingNote = await _context.Notes.FindAsync(NewNote.NoteId);
            if (existingNote != null)
            {
                existingNote.Title = NewNote.Title;
                existingNote.Content = NewNote.Content;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var note = await _context.Notes.FindAsync(DeleteNoteId);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
