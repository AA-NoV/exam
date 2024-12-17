using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoExam.Models;

namespace DemoExam.Data
{
    public class DemoExamContext : DbContext
    {
        public DemoExamContext (DbContextOptions<DemoExamContext> options)
            : base(options)
        {
        }

        public DbSet<DemoExam.Models.User> User { get; set; } = default!;
        public DbSet<DemoExam.Models.Master> Master { get; set; }

    }
}
