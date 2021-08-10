using EFManyToManyRelationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFManyToManyRelationships.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly DefaultDbContext _context;

      public HomeController(ILogger<HomeController> logger, DefaultDbContext context)
      {
         _logger = logger;
         _context = context;
      }

      public IActionResult Index()
      {
         var teacher = _context.Teachers.Include(x => x.Students).FirstOrDefault();
         return View();
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
