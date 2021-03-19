using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer.Database
{
    public class TesterContex : DbContext
    {
        //Удалить эту гадость
        ~TesterContex()
        {
            Dispose();
        }
        private static TesterContex instance;
        public static TesterContex Init()
        {
            if (instance is null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TesterContex>();
                var options = optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=betatesterdb;Trusted_Connection=True;").Options;
                instance = new TesterContex(options);
            }
            return instance;
        }
        public TesterContex()
        {
            Database.EnsureCreated();
        }


        public DbSet<AnswerEntity> Answers { get; internal set; }
        public DbSet<AttemptEntity> Attempts { get; internal set; }
        public DbSet<TestItemEntity> TestItems { get; internal set; }
        public DbSet<QuestionEntity> Questions { get; internal set; }
        public DbSet<QuestionDifficultyEntity> QuestionDifficulties { get; internal set; }

        public TesterContex(DbContextOptions<TesterContex> options) : base(options)
        {
            Database.EnsureCreated();
            //var q001 = new Question(0, "2 * 2 = ?");
            //var q002 = new Question(0, "Capital of GB");
            //var q003 = new Question(0, "Amount of legs of single spider");

            //var q004 = new Question(1, "Rectangle's angle size");
            //var q005 = new Question(1, "Year of New World discovery");
            //var q006 = new Question(1, "Chemichal formula of default salt");

            //var q007 = new Question(2, "First 11 digits of Pi");
            //var q008 = new Question(2, "Dynasty of legit emperors");
            //var q009 = new Question(2, "Chemichal formula of pervitin");

            //var a01q001 = new Answer(true, q001, "4");
            //var a02q001 = new Answer(false, q001, "0");
            //var a03q001 = new Answer(false, q001, "2");
            //var a04q001 = new Answer(false, q001, "3");
            //var a05q001 = new Answer(false, q001, "5");
            //q001.Answers.Add(a01q001);
            //q001.Answers.Add(a02q001);
            //q001.Answers.Add(a03q001);
            //q001.Answers.Add(a04q001);
            //q001.Answers.Add(a05q001);

            //var a01q002 = new Answer(true, q002, "London");
            //var a02q002 = new Answer(false, q002, "Edinburg");
            //var a03q002 = new Answer(false, q002, "Cardiff");
            //var a04q002 = new Answer(false, q002, "Dublin");
            //var a05q002 = new Answer(false, q002, "Moscow");
            //q002.Answers.Add(a01q002);
            //q002.Answers.Add(a02q002);
            //q002.Answers.Add(a03q002);
            //q002.Answers.Add(a04q002);
            //q002.Answers.Add(a05q002);

            //var a01q003 = new Answer(true, q003, "8");
            //var a02q003 = new Answer(false, q003, "2");
            //var a03q003 = new Answer(false, q003, "4");
            //var a04q003 = new Answer(false, q003, "6");
            //var a05q003 = new Answer(false, q003, "50");
            //q003.Answers.Add(a01q003);
            //q003.Answers.Add(a02q003);
            //q003.Answers.Add(a03q003);
            //q003.Answers.Add(a04q003);
            //q003.Answers.Add(a05q003);

            //var a01q004 = new Answer(true, q004, "90");
            //var a02q004 = new Answer(false, q004, "60");
            //var a03q004 = new Answer(false, q004, "100");
            //var a04q004 = new Answer(false, q004, "45");
            //var a05q004 = new Answer(false, q004, "97");
            //q004.Answers.Add(a01q004);
            //q004.Answers.Add(a02q004);
            //q004.Answers.Add(a03q004);
            //q004.Answers.Add(a04q004);
            //q004.Answers.Add(a05q004);

            //var a01q005 = new Answer(true, q005, "1492");
            //var a02q005 = new Answer(false, q005, "1453");
            //var a03q005 = new Answer(false, q005, "1499");
            //var a04q005 = new Answer(false, q005, "1444");
            //var a05q005 = new Answer(false, q005, "1962");
            //q005.Answers.Add(a01q005);
            //q005.Answers.Add(a02q005);
            //q005.Answers.Add(a03q005);
            //q005.Answers.Add(a04q005);
            //q005.Answers.Add(a05q005);

            //var a01q006 = new Answer(true, q006, "NaCl");
            //var a02q006 = new Answer(false, q006, "C2H5OH");
            //var a03q006 = new Answer(false, q006, "CuSO4");
            //var a04q006 = new Answer(false, q006, "CaCO3");
            //var a05q006 = new Answer(false, q006, "H2CO3");
            //q006.Answers.Add(a01q006);
            //q006.Answers.Add(a02q006);
            //q006.Answers.Add(a03q006);
            //q006.Answers.Add(a04q006);
            //q006.Answers.Add(a05q006);

            //var a01q007 = new Answer(true, q007, "3.1415926535");
            //var a02q007 = new Answer(false, q007, "3.1415926536");
            //var a03q007 = new Answer(false, q007, "3.1415926545");
            //var a04q007 = new Answer(false, q007, "3.1415926546");
            //var a05q007 = new Answer(false, q007, "3.1415925535");
            //q007.Answers.Add(a01q007);
            //q007.Answers.Add(a02q007);
            //q007.Answers.Add(a03q007);
            //q007.Answers.Add(a04q007);
            //q007.Answers.Add(a05q007);

            //var a01q008 = new Answer(true, q008, "von Habsburg");
            //var a02q008 = new Answer(false, q008, "di Valois");
            //var a03q008 = new Answer(false, q008, "di Bourbonnais");
            //var a04q008 = new Answer(false, q008, "Trastamara");
            //var a05q008 = new Answer(false, q008, "Romanov");
            //q008.Answers.Add(a01q008);
            //q008.Answers.Add(a02q008);
            //q008.Answers.Add(a03q008);
            //q008.Answers.Add(a04q008);
            //q008.Answers.Add(a05q008);

            //var a01q009 = new Answer(true, q009, "C10H15N");
            //var a02q009 = new Answer(false, q009, "C9H13N");
            //var a03q009 = new Answer(false, q009, "C8H11NO2");
            //var a04q009 = new Answer(false, q009, "C6H12O6");
            //var a05q009 = new Answer(false, q009, "C2H5OH");
            //q009.Answers.Add(a01q009);
            //q009.Answers.Add(a02q009);
            //q009.Answers.Add(a03q009);
            //q009.Answers.Add(a04q009);
            //q009.Answers.Add(a05q009);


            //Questions = new HashSet<Question>() { q001, q002, q003, q004, q005, q006, q007, q008, q009 };
            //Answers = new HashSet<Answer>() 
            //{ 
            //    a01q001, a02q001, a03q001, a04q001, a05q001,
            //    a01q002, a02q002, a03q002, a04q002, a05q002,
            //    a01q003, a02q003, a03q003, a04q003, a05q003,
            //    a01q004, a02q004, a03q004, a04q004, a05q004,
            //    a01q005, a02q005, a03q005, a04q005, a05q005,
            //    a01q006, a02q006, a03q006, a04q006, a05q006,
            //    a01q007, a02q007, a03q007, a04q007, a05q007,
            //    a01q008, a02q008, a03q008, a04q008, a05q008,
            //    a01q009, a02q009, a03q009, a04q009, a05q009,
            //};

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QuestionEntity>();


            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
