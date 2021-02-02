using Microsoft.EntityFrameworkCore;
using OnlineExaminationSystemAPI.Models;


namespace OnlineExaminationSystemAPI.Models
{
    public class OESContext : DbContext
    {
        public OESContext(DbContextOptions<OESContext> options)
            : base(options)
        {
        }
        public DbSet<TestMaster> TestMaster { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<QuestionMaster> QuestionMaster { get; set; }
        public DbSet<AnswerMaster> AnswerMaster { get; set; }
        public DbSet<TestQuestionMapping> TestQuestionMapping { get; set; }
        public DbSet<OnlineExaminationSystemAPI.Models.Registration> Registration { get; set; }
    }
}
