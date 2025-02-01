using PT2Revision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PT2Revision.Models.ViewModels;

namespace PT2Revision.Controllers
{
    public class HomeController : Controller
    {
        SchoolDBContext SdbContext;
        public HomeController(SchoolDBContext context)
        {
            SdbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewStudentsResults(int? selectedModuleId)
        {
            ICollection<StudentResults> studentResults;
            if(selectedModuleId != null)
            {
                studentResults = (from studentResult in SdbContext.StudentResults
                                  where studentResult.ModuleId.Equals(selectedModuleId)
                                  select studentResult).Include(m => m.Module).Include(s=>s.Student).ToList();
            }
            else
            {

                 studentResults = SdbContext.StudentResults.Include(m=>m.Module).Include(s=>s.Student).ToList();
            }
            return View(studentResults);
        }
        [HttpGet]
        public IActionResult AddStudentResults()
        {
            StudentResultsVM studentResultsVM = new StudentResultsVM();
            studentResultsVM.modules = SdbContext.Modules.ToList();
            studentResultsVM.students = SdbContext.Students.ToList();

            return View(studentResultsVM);
        }
        [HttpPost]
        public ActionResult AddStudentResults(StudentResultsVM studentResultsVM)
        {
            if (ModelState.IsValid)
            {
                studentResultsVM.SelectedModule = studentResultsVM.studentResults.ModuleId; 
                SdbContext.StudentResults.Add(studentResultsVM.studentResults);
                SdbContext.SaveChanges();
                return RedirectToAction("ViewStudentsResults", new { selectedModuleId = studentResultsVM.studentResults.ModuleId });
            }
            studentResultsVM.modules = SdbContext.Modules.ToList();
            studentResultsVM.students = SdbContext.Students.ToList();
            return View(studentResultsVM);
        }

    }
}
