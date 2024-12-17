using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoExam.Data;
using DemoExam.Models;

namespace DemoExam.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly DemoExamContext _context;

        public CreateModel(DemoExamContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Загружаем список мастеров для выпадающего списка
            Masters = _context.Master.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            }).Distinct().ToList(); // Используем Distinct для удаления дубликатов

            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // Добавляем свойство для списка мастеров
        public List<SelectListItem> Masters { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Если модель не валидна, загружаем мастеров снова для отображения в форме
                Masters = _context.Master.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                }).ToList();
                return Page();
            }

            _context.User.Add(User); // Обратите внимание на правильное имя DbSet
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}