using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinanceDummy.Models;
using TibFinanceDummy.Models.ViewModel;

namespace TibFinanceDummy.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        tibfinancedummydbEntities4 db = new tibfinancedummydbEntities4();
        public ActionResult Index()
        {
            List<Student> students = db.Students.ToList();
            ViewBag.ListOfStudent = new SelectList(students, "StudentId", "StudentName");
            return View();
        }
        public JsonResult GetGradesAndStudent(int page = 1 ,int pageSize = 10)
        {
            var gradeList = (from student in db.Students
                            join grade in db.Grades
                            on student.StudentId equals grade.StudentId
                            select new
                            {
                                student.StudentId,
                                student.StudentName,
                                student.Roll,
                                student.Address,
                                grade.GradeName, 
                                grade.GradeId

                            }).ToList().Skip((page-1)*pageSize).Take(pageSize);
            return Json(gradeList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddGrade(GradeViewModel gradeViewModel)
        {
            var result = false;
            if (gradeViewModel.GradeId > 0)
            {
                var grade = db.Grades.Where(x => x.GradeId == gradeViewModel.GradeId).FirstOrDefault();
                if (grade != null)
                {
                    grade.GradeName = gradeViewModel.GradeName;
                    grade.StudentId = gradeViewModel.StudentId;
                }
                result = true;
                db.SaveChanges();
            }
            else
            {
                var grade = new Grade()
                {
                    GradeName = gradeViewModel.GradeName,
                    StudentId = gradeViewModel.StudentId,
                };
                db.Grades.Add(grade);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteGradeRecord(int GradeId)
        {
            bool result = false;
            Grade grade = db.Grades.Find(GradeId);
            if(grade != null)
            {
                db.Grades.Remove(grade);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}