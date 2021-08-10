using EFManyToManyRelationships.Models;
using Microsoft.EntityFrameworkCore;

namespace EFManyToManyRelationships
{
   public class DefaultDbContext : DbContext
   {
      public DefaultDbContext(DbContextOptions options) : base(options)
      {

      }

      public DbSet<Teacher> Teachers { get; set; }
      public DbSet<Student> Students { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Teacher>().HasData(
            new Teacher() { Id = 1, Name = " teacher 1" },
            new Teacher() { Id = 2, Name = " teacher 2" },
            new Teacher() { Id = 3, Name = " teacher 3" }
         );

         modelBuilder.Entity<Student>().HasData(
            new Student() { Id = 1, Name = "Student 1" },
            new Student() { Id = 2, Name = "Student 2" },
            new Student() { Id = 3, Name = "Student 3" },
            new Student() { Id = 4, Name = "Student 4" }
         );

         modelBuilder
            .Entity<Teacher>()
            .HasMany(p => p.Students)
            .WithMany(p => p.Teachers)
            .UsingEntity(j => j.HasData(
               new { TeachersId = 1, StudentsId = 1 },
               new { TeachersId = 1, StudentsId = 2 },
               new { TeachersId = 1, StudentsId = 3 },
               new { TeachersId = 1, StudentsId = 4 },
               new { TeachersId = 2, StudentsId = 2 },
               new { TeachersId = 2, StudentsId = 3 },
               new { TeachersId = 3, StudentsId = 1 },
               new { TeachersId = 3, StudentsId = 4 }
            ));
      }
   }
}
