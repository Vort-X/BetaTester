using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Database
{
    public class TesterContext : DbContext
    {
        public TesterContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<AnswerEntity> Answers { get; internal set; }
        public DbSet<AttemptEntity> Attempts { get; internal set; }
        public DbSet<TestItemEntity> TestItems { get; internal set; }
        public DbSet<QuestionEntity> Questions { get; internal set; }
        public DbSet<QuestionDifficultyEntity> QuestionDifficulties { get; internal set; }

        public TesterContext(DbContextOptions<TesterContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=betatesterdb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
