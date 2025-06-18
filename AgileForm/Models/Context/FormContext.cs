using Microsoft.EntityFrameworkCore;

namespace AgileForm.Models.Context
{
    public class FormContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AgileForm;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
