using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoExam.Data;
using DemoExam.Models;

namespace DemoExam.Pages.Masters
{
    public class CreateModel : PageModel
    {
        private readonly DemoExam.Data.DemoExamContext _context;

        public CreateModel(DemoExam.Data.DemoExamContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Master Master { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Master.Add(Master);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
