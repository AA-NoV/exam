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
    public class IndexModel : PageModel
    {
        private readonly DemoExam.Data.DemoExamContext _context;

        public IndexModel(DemoExam.Data.DemoExamContext context)
        {
            _context = context;
        }

        public IList<Master> Master { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Master = await _context.Master.ToListAsync();
        }
    }
}
