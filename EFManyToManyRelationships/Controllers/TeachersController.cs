using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFManyToManyRelationships.Controllers
{
   public class TeachersController : Controller
   {
      private readonly DefaultDbContext _context;

      public TeachersController(DefaultDbContext context)
      {
         _context = context;
      }

      // GET: Teachers
      public async Task<IActionResult> Index()
      {
         var teachers = await _context.Teachers.Include(t => t.Students).ToListAsync();
         return View(teachers);
      }

      // GET: Teachers/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var teacher = await _context.Teachers.Include(t => t.Students)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (teacher == null)
         {
            return NotFound();
         }

         return View(teacher);
      }

   }
}
