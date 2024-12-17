using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoExam.Data;
using DemoExam.Models;

namespace DemoExam.Pages.Masters
{
    public class DeleteModel : PageModel
    {
        private readonly DemoExam.Data.DemoExamContext _context;

        public DeleteModel(DemoExam.Data.DemoExamContext context)
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

            var master = await _context.Master.FirstOrDefaultAsync(m => m.Id == id);

            if (master == null)
            {
                return NotFound();
            }
            else
            {
                Master = master;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Master.FindAsync(id);
            if (master != null)
            {
                Master = master;
                _context.Master.Remove(Master);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
