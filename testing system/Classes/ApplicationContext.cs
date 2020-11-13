using Microsoft.EntityFrameworkCore;
using testing_system.Classes;
using testing_system.Classes.ForDataBase;

namespace testing_system
{
    class ApplicationContext : DbContext
    {
        /// <summary>
        /// Набор объектов хранимых в БД 
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<StatisticOfTest> statisticOfTests { get; set; }
        public DbSet<TestName> testNames { get; set; }
        public DbSet<QuestionAndAnswer> questionAndAnswers { get; set; }
        public DbSet<QuestionName> questionNames { get; set; }
        public DbSet<UserAnswer> userAnswers { get; set; }
        public DbSet<InformationAboutMath> informationAboutMaths { get; set; }

        /// <summary>
        /// Необходим для создания БД
        /// </summary>
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Необходим для установки свойств подключения
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testing_system_db;Trusted_Connection=True;");
        }

        /// <summary>
        /// Метод необходим для определения первичных и составных ключей в таблицах
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //первичные ключи
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<StatisticOfTest>().HasKey(k => new { k.UserID, k.TestID, k.Attempt });
            modelBuilder.Entity<TestName>().HasKey(u =>  u.TestID);
            modelBuilder.Entity<QuestionAndAnswer>().HasKey(k => new { k.TestID, k.QuestionID });
            modelBuilder.Entity<QuestionName>().HasKey(k => new { k.QuestionID, k.TestID });
            modelBuilder.Entity<UserAnswer>().HasKey(k => new { k.TestID, k.QuestionID, k.UserID, k.Attempt });
            modelBuilder.Entity<InformationAboutMath>().HasKey(k => k.ThemeID);
        }
    }
}