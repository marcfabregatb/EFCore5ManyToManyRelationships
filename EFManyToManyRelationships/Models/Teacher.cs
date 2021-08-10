using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFManyToManyRelationships.Models
{
   public class Teacher
   {
      [Key]
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }

      public ICollection<Student> Students { get; set; }
   }
}
