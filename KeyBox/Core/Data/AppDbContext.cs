using KeyBox.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeyBox.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Quizz> Quizzs { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
    }

}
