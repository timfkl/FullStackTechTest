using System.Diagnostics;
using DAL;
using Models;
using Microsoft.AspNetCore.Mvc;
using FullStackTechTest.Models.Import;
using FullStackTechTest.Models.Shared;

namespace FullStackTechTest.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(List<Person> people, List<Address> address) {
            
        }
    }
}
