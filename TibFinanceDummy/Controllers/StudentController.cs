using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinanceDummy.Models;
using TibFinanceDummy.Models.ViewModel;

namespace TibFinanceDummy.Controllers
{
    public class StudentController : Controller
    {
        tibfinancedummydbEntities4 db = new tibfinancedummydbEntities4();
        // GET: Student
        public ActionResult Index()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.ListOfDepartment = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }
        public JsonResult GetStudentList()
        {
            var studentList = from student in db.Students
                              join department in db.Departments
                              on student.DepartmentId equals department.DepartmentId
                              select new
                              {
                                  student.StudentId,
                                  student.StudentName,
                                  student.Address,
                                  student.Roll,
                                  DepartmentName = department.DepartmentName
                              };
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudentById(int? studentId)
        {
            Student singleStudent = db.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(singleStudent, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddStudent(StudentViewModel studentViewModel)
        {
            var result = false;
            if (studentViewModel.StudentId > 0)
            {

                Student student = db.Students.Where(x => x.StudentId == studentViewModel.StudentId).FirstOrDefault();
                //Student student = new Student();
                student.StudentName = studentViewModel.StudentName;
                student.Roll = studentViewModel.Roll;
                student.Address = studentViewModel.Address;
                student.DepartmentId = studentViewModel.DepartmentId;
                result = true;
                db.SaveChanges();
            }
            else
            {
                Student student = new Student();
                student.StudentName = studentViewModel.StudentName;
                student.Address = studentViewModel.Address;
                student.Roll = studentViewModel.Roll;
                student.DepartmentId = studentViewModel.DepartmentId;
                db.Students.Add(student); db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteStudentRecord(int StudentId)
        {
            bool result = false;
            Student student = db.Students.Find(StudentId);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                result = true;
            }
           

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}