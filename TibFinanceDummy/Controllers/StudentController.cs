using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TibFinanceDummy.Models;
using TibFinanceDummy.Models.ViewModel;

namespace TibFinanceDummy.Controllers
{
    public class StudentController : Controller
    {
        Model1 db = new Model1();
        // GET: Student
        public ActionResult Index()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.ListOfDepartment = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }
        public JsonResult GetStudentList(int page = 1,int pageSize = 10)
        {
            
            var studentList =( from student in db.Students
                              join department in db.Departments
                              on student.DepartmentId equals department.DepartmentId 
                              join info in db.StudentDetailInfos
                              on student.StudentId equals info.StudentId into studentDetailInfos 
                              from studentDetailInfo in studentDetailInfos.DefaultIfEmpty()
                              select new
                              {
                                  student.StudentId,
                                  student.StudentName,
                                  student.Roll,
                                  student.Address,
                                  department.DepartmentId,
                                  department.DepartmentName,
                                  studentDetailInfo.Std_Father_Name,
                                  studentDetailInfo.Std_Mother_Name,
                                  studentDetailInfo.Std_Gender,
                                  studentDetailInfo.Std_Phone,
                                  studentDetailInfo.Std_BloodGroup,
                                  TotalData=(db.Students.Count())
                              }).ToList().Skip((page - 1) * pageSize).Take(pageSize);
          
          // var pagedStudentList = studentList.Skip(skip).Take(pageSize);
          // var pagedStudentList = studentList.Skip(skip).Take(pageSize);

            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentById(int? studentId)
        {
            var singleStudent = (from student in db.Students
                                join department in db.Departments
                                on student.DepartmentId equals department.DepartmentId
                                join info in db.StudentDetailInfos
                                on student.StudentId equals info.StudentId into studentDetailInfos
                                from studentDetailInfo in studentDetailInfos.DefaultIfEmpty()
                                where student.StudentId == studentId
                                select new
                                {
                                    student.StudentId,
                                    student.StudentName,
                                    student.Roll,
                                    student.Address,
                                    department.DepartmentId,
                                    department.DepartmentName,
                                    studentDetailInfo.Std_Father_Name,
                                    studentDetailInfo.Std_Mother_Name,
                                    studentDetailInfo.Std_Gender,
                                    studentDetailInfo.Std_Phone,
                                    studentDetailInfo.Std_BloodGroup
                                }).FirstOrDefault();
            //Student singleStudent = db.Students.Where(x => x.StudentId == studentId).FirstOrDefault();
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
                var student = db.Students.Where(x => x.StudentId == studentViewModel.StudentId).FirstOrDefault();
                if (student != null)
                {
                    student.StudentName = studentViewModel.StudentName;
                    student.Address = studentViewModel.Address;
                    student.DepartmentId = studentViewModel.DepartmentId;
                    student.Roll = studentViewModel.Roll;
                    //exSt.StudentId=
                }
                var info = db.StudentDetailInfos.Where(x => x.StudentId == studentViewModel.StudentId).FirstOrDefault();
                if (info != null)
                {
                    info.Std_Father_Name = studentViewModel.Std_Father_Name;
                    info.Std_Mother_Name = studentViewModel.Std_Mother_Name;
                    info.Std_BloodGroup = studentViewModel.Std_BloodGroup;
                    info.Std_Phone = studentViewModel.Std_Phone;
                    info.Std_Gender = studentViewModel.Std_Gender;
                    info.Std_BloodGroup = studentViewModel.Std_BloodGroup;
                }

                result = true;
                db.SaveChanges();
            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string fname;
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                            }
                            else
                            {
                                fname = file.FileName;
                            }
                            fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                            file.SaveAs(fname);
                            Student studentImgObj = new Student()
                            {
                                ImagePath = fname
                            };
                            var student = new Student()
                            {
                                StudentName = studentViewModel.StudentName,
                                Roll = studentViewModel.Roll,
                                Address = studentViewModel.Address,
                                DepartmentId = studentViewModel.DepartmentId,
                                ImagePath = fname

                            };
                            var studentDetailInfo = new StudentDetailInfo()
                            {
                                Std_BloodGroup = studentViewModel.Std_BloodGroup,
                                Std_Father_Name = studentViewModel.Std_Father_Name,
                                Std_Gender = studentViewModel.Std_Gender,
                                Std_Phone = studentViewModel.Std_Phone,
                                Std_Mother_Name = studentViewModel.Std_Mother_Name,
                            };
                            db.Students.Add(student);
                            db.StudentDetailInfos.Add(studentDetailInfo);
                            db.SaveChanges();
                            return Json("File Uploaded Successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        return Json("Error occurred. Error details: " + ex.Message);
                    }
                }
                else
                {
                    return Json("No files selected.");
                }
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

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(User user)
        {
            User u = new User();
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.Password = user.Password;
            db.Users.Add(u);
            db.SaveChanges();
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            User user = new User();
            var userCredentials = from c in db.Users where c.UserName == username && c.Password == password select c;
            if (userCredentials.Count() > 0)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}