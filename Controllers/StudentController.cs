using CollegeWebsite.Data;
using CollegeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace CollegeWebsite.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = "Please login";
                return View("LoginForm");
            }
            else
            {
                return View();
            }
        }

        public ActionResult RegisterForm()
        {
            return View();
        }

        public ActionResult ForgotForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(StudentUserModel studentUserModel)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();
            
            if(studentUserDAO.CheckStudent(studentUserModel) == true)
            {
                if(studentUserDAO.CheckUser(studentUserModel) == true)
                {
                    ViewBag.Message = "User already exists";
                    return View("RegisterForm");
                }
                else
                {
                    studentUserDAO.CreateRecord(studentUserModel);
                    return View("LoginForm");
                }  
            }
            else
            {
                ViewBag.Message = "Student ID does not exist";
                return View("RegisterForm");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(StudentUserModel studentUserModel)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();

            if (studentUserDAO.CheckUser(studentUserModel) == true)
            {
                studentUserDAO.UpdateRecord(studentUserModel);
                return View("LoginForm");
            }
            else
            {
                ViewBag.Message = "User does not exist";
                return View("RegisterForm");
            }
        }

        public bool IsLoggedIn()
        {
            StudentUserModel _uobj = Session["userInfo"] as StudentUserModel;
            if (_uobj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentUserModel studentUserModel)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();

            if (studentUserDAO.CheckPass(studentUserModel) == true)
            {
                Session["userInfo"] = studentUserModel;
                return View("Index");
            }
            else
            {
                ViewBag.Message = ("Incorrect User ID or Password");
                return View("LoginForm");
            }
        }

        public ActionResult LoginForm()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("LoginForm");
        }

        public ActionResult StudentUserEdit(int Id)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();
            StudentUserModel studentUserModel = studentUserDAO.FetchOne(Id);
            return View("RegisterForm", studentUserModel);
        }

        public ActionResult StudentDetails()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = "Please login";
                return View("LoginForm");
            }
            else
            {
                StudentUserModel _uobj = Session["userInfo"] as StudentUserModel;
                StudentDAO studentDAO = new StudentDAO();
                StudentModel student = studentDAO.FetchOne(_uobj.StudentID);
                return View("StudentDetails", student);
            }
        }

        public ActionResult AccountDetails()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = "Please login";
                return View("LoginForm");
            }
            else
            {
                StudentUserModel _uobj = Session["userInfo"] as StudentUserModel;
                StudentUserDAO studentUserDAO = new StudentUserDAO();
                StudentUserModel student = studentUserDAO.FetchOne(_uobj.StudentID);
                return View("AccountDetails", student);
            }
        }

        public ActionResult AccountDelete()
        {
            StudentUserModel _uobj = Session["userInfo"] as StudentUserModel;
            StudentUserDAO studentUserDAO = new StudentUserDAO();
            studentUserDAO.DeleteRecord(_uobj.StudentID);
            Session.Clear();
            ViewBag.Message = "Account deleted";
            return View("LoginForm");
        }

        public ActionResult AccountEditForm()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = "Please login";
                return View("LoginForm");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AccountEdit(int Id)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();
            StudentUserModel studentUserModel = studentUserDAO.FetchOne(Id);
            return View("AccountEditForm", studentUserModel);
        }

        public ActionResult AccountUpdate(StudentUserModel studentUserModel)
        {
            StudentUserDAO studentUserDAO = new StudentUserDAO();
            studentUserDAO.UpdateRecord(studentUserModel);
            return View("Index");
        }

        public ActionResult DisplayResults()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = "Please login";
                return View("LoginForm");
            }
            else
            {
                StudentUserModel _uobj = Session["userInfo"] as StudentUserModel;
                List<ResultModel> result = new List<ResultModel>();
                ResultDAO resultDAO = new ResultDAO();
                result = resultDAO.FetchSelect(_uobj.StudentID);

                return View(result);
            }
        }
    }
}