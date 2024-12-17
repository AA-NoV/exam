using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoExam.Data;
using DemoExam.Models;

namespace DemoExam.Pages.Masters
{
    public class EditModel : PageModel
    {
        private readonly DemoExam.Data.DemoExamContext _context;

        public EditModel(DemoExam.Data.DemoExamContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Master Master { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master =  await _context.Master.FirstOrDefaultAsync(m => m.Id == id);
            if (master == null)
            {
                return NotFound();
            }
            Master = master;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterExists(Master.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasterExists(int id)
        {
            return _context.Master.Any(e => e.Id == id);
        }
    }
}
