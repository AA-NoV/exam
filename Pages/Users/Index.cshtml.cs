using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoExam.Data;
using DemoExam.Models;

namespace DemoExam.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly DemoExam.Data.DemoExamContext _context;

        public IndexModel(DemoExam.Data.DemoExamContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User
                .Include(u => u.Master).ToListAsync();
        }
    }
}
