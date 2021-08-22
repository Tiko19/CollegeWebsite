using CollegeWebsite.Data;
using CollegeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeWebsite.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }
            else
            {
                return View();
            }
        }

        public bool IsLoggedIn()
        {
            UserModel _uobj = Session["userInfo"] as UserModel;
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
        public ActionResult Login(UserModel userModel)
        {
            UserDAO userDAO = new UserDAO();
            
            if(userDAO.CheckPass(userModel) == true)
            {
                Session["userInfo"] = userModel;
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

        public ActionResult UserCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult UserEdit(int Id)
        {
            UserDAO userDAO = new UserDAO();
            UserModel userModel = userDAO.FetchOne(Id);
            return View("UserCreate", userModel);
        }

        public ActionResult UserDelete(int id)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.DeleteRecord(id);
            List<UserModel> result = userDAO.FetchAll();
            return View("UserList", result);
        }

        public ActionResult UserList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }
            else
            {
                List<UserModel> result = new List<UserModel>();
                UserDAO userDAO = new UserDAO();
                result = userDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewUserObject(UserModel userModel)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.CreateOrUpdateRecord(userModel);

            return View("UserDetails", userModel);
        }

        public ActionResult UserDetails(int id)
        {
            UserDAO userDAO = new UserDAO();
            UserModel result = userDAO.FetchOne(id);
            return View("UserDetails", result);
        }


        ///Bachelor programs
        public ActionResult BachelorCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult BachelorEdit(int Id)
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                BachelorDAO bachelorDAO = new BachelorDAO();
                ProgramsModel programsModel = bachelorDAO.FetchOne(Id);
                return View("BachelorCreate", programsModel);
            }
        }

        public ActionResult BachelorDelete(int id)
        {
            BachelorDAO bachelorDAO = new BachelorDAO();
            bachelorDAO.DeleteRecord(id);
            List<ProgramsModel> result = bachelorDAO.FetchAll();
            return View("BachelorList", result);
        }

        public ActionResult NewBachelorObject(ProgramsModel programsModel)
        {
            BachelorDAO bachelorDAO = new BachelorDAO();
            bachelorDAO.CreateOrUpdateRecord(programsModel);

            return View("BachelorDetails", programsModel);
        }

        public ActionResult BachelorList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<ProgramsModel> result = new List<ProgramsModel>();
                BachelorDAO bachelorDAO = new BachelorDAO();
                result = bachelorDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult BachelorDetails(int id)
        {
            BachelorDAO bachelorDAO = new BachelorDAO();
            ProgramsModel result = bachelorDAO.FetchOne(id);
            return View("BachelorDetails", result);
        }



        ///Master programs
        public ActionResult MasterCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult MasterEdit(int Id)
        {
            MasterDAO masterDAO = new MasterDAO();
            ProgramsModel programsModel = masterDAO.FetchOne(Id);
            return View("MasterCreate", programsModel);
        }

        public ActionResult MasterDelete(int id)
        {
            MasterDAO masterDAO = new MasterDAO();
            masterDAO.DeleteRecord(id);
            List<ProgramsModel> result = masterDAO.FetchAll();
            return View("MasterList", result);
        }

        public ActionResult MasterList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<ProgramsModel> result = new List<ProgramsModel>();
                MasterDAO masterDAO = new MasterDAO();
                result = masterDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewMasterObject(ProgramsModel programsModel)
        {
            MasterDAO masterDAO = new MasterDAO();
            masterDAO.CreateOrUpdateRecord(programsModel);

            return View("MasterDetails", programsModel);
        }

        public ActionResult MasterDetails(int id)
        {
            MasterDAO masterDAO = new MasterDAO();
            ProgramsModel result = masterDAO.FetchOne(id);
            return View("MasterDetails", result);
        }



        ///Non-degree programs
        public ActionResult NonDegreeCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult NonDegreeEdit(int Id)
        {
            NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
            ProgramsModel programsModel = nonDegreeDAO.FetchOne(Id);
            return View("NonDegreeCreate", programsModel);
        }

        public ActionResult NonDegreeDelete(int id)
        {
            NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
            nonDegreeDAO.DeleteRecord(id);
            List<ProgramsModel> result = nonDegreeDAO.FetchAll();
            return View("NonDegreeList", result);
        }

        public ActionResult NonDegreeList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<ProgramsModel> result = new List<ProgramsModel>();
                NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
                result = nonDegreeDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewNonDegreeObject(ProgramsModel programsModel)
        {
            NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
            nonDegreeDAO.CreateOrUpdateRecord(programsModel);

            return View("NonDegreeDetails", programsModel);
        }

        public ActionResult NonDegreeDetails(int id)
        {
            NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
            ProgramsModel result = nonDegreeDAO.FetchOne(id);
            return View("NonDegreeDetails", result);
        }



        ///Students
        public ActionResult StudentCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult StudentEdit(int Id)
        {
            StudentDAO studentDAO = new StudentDAO();
            StudentModel studentModel = studentDAO.FetchOne(Id);
            return View("StudentCreate", studentModel);
        }

        public ActionResult StudentDelete(int id)
        {
            StudentDAO studentDAO = new StudentDAO();
            studentDAO.DeleteRecord(id);
            List<StudentModel> result = studentDAO.FetchAll();
            return View("StudentList", result);
        }


        public ActionResult StudentList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<StudentModel> result = new List<StudentModel>();
                StudentDAO studentDAO = new StudentDAO();
                result = studentDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewStudentObject(StudentModel studentModel)
        {
            StudentDAO studentDAO = new StudentDAO();
            studentDAO.CreateOrUpdateRecord(studentModel);

            return View("StudentDetails", studentModel);
        }

        public ActionResult StudentDetails(int id)
        {
            StudentDAO studentDAO = new StudentDAO();
            StudentModel result = studentDAO.FetchOne(id);
            return View("StudentDetails", result);
        }


        ///Students
        public ActionResult ResultCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult ResultEdit(int Id)
        {
            ResultDAO resultDAO = new ResultDAO();
            ResultModel resultModel = resultDAO.FetchOne(Id);
            return View("ResultCreate", resultModel);
        }

        public ActionResult ResultDelete(int id)
        {
            ResultDAO resultDAO = new ResultDAO();
            resultDAO.DeleteRecord(id);
            List<ResultModel> result = resultDAO.FetchAll();
            return View("ResultList", result);
        }


        public ActionResult ResultList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<ResultModel> result = new List<ResultModel>();
                ResultDAO resultDAO = new ResultDAO();
                result = resultDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewResultObject(ResultModel resultModel)
        {
            ResultDAO resultDAO = new ResultDAO();
            resultDAO.CreateOrUpdateRecord(resultModel);

            return View("ResultDetails", resultModel);
        }

        public ActionResult ResultDetails(int id)
        {
            ResultDAO resultDAO = new ResultDAO();
            ResultModel result = resultDAO.FetchOne(id);
            return View("ResultDetails", result);
        }




        ///Office and faculty
        public ActionResult FacultyCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult FacultyEdit(int Id)
        {
            FacultyDAO facultyDAO = new FacultyDAO();
            FacultyModel facultyModel = facultyDAO.FetchOne(Id);
            return View("FacultyCreate", facultyModel);
        }

        public ActionResult FacultyDelete(int id)
        {
            FacultyDAO facultyDAO = new FacultyDAO();
            facultyDAO.DeleteRecord(id);
            List<FacultyModel> result = facultyDAO.FetchAll();
            return View("FacultyList", result);
        }

        public ActionResult FacultyList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<FacultyModel> result = new List<FacultyModel>();
                FacultyDAO facultyDAO = new FacultyDAO();
                result = facultyDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewFacultyObject(FacultyModel facultyModel)
        {
            FacultyDAO facultyDAO = new FacultyDAO();
            facultyDAO.CreateOrUpdateRecord(facultyModel);

            return View("FacultyDetails", facultyModel);
        }

        public ActionResult FacultyDetails(int id)
        {
            FacultyDAO facultyDAO = new FacultyDAO();
            FacultyModel result = facultyDAO.FetchOne(id);
            return View("FacultyDetails", result);
        }



        ///Dates and deadlines
        public ActionResult DatesDeadlinesCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult DatesDeadlinesEdit(int Id)
        {
            DeadlineDAO deadlineDAO = new DeadlineDAO();
            DeadlineModel deadlineModel = deadlineDAO.FetchOne(Id);
            return View("DatesDeadlinesCreate", deadlineModel);
        }

        public ActionResult DatesDeadlinesDelete(int id)
        {
            DeadlineDAO deadlineDAO = new DeadlineDAO();
            deadlineDAO.DeleteRecord(id);
            List<DeadlineModel> result = deadlineDAO.FetchAll();
            return View("DatesDeadlinesList", result);
        }

        public ActionResult DatesDeadlinesList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<DeadlineModel> result = new List<DeadlineModel>();
                DeadlineDAO deadlineDAO = new DeadlineDAO();
                result = deadlineDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewDeadlinesObject(DeadlineModel deadlineModel)
        {
            DeadlineDAO deadlineDAO = new DeadlineDAO();
            deadlineDAO.CreateOrUpdateRecord(deadlineModel);

            return View("DatesDeadlinesDetails", deadlineModel);
        }

        public ActionResult DatesDeadlinesDetails(int id)
        {
            DeadlineDAO deadlineDAO = new DeadlineDAO();
            DeadlineModel result = deadlineDAO.FetchOne(id);
            return View("DatesDeadlinesDetails", result);
        }

        ///News and Notices
        public ActionResult NoticeCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult NoticeEdit(int Id)
        {
            NoticeDAO noticeDAO = new NoticeDAO();
            NoticeModel noticeModel = noticeDAO.FetchOne(Id);
            return View("NoticeCreate", noticeModel);
        }

        public ActionResult NoticeDelete(int id)
        {
            NoticeDAO noticeDAO = new NoticeDAO();
            noticeDAO.DeleteRecord(id);
            List<NoticeModel> result = noticeDAO.FetchAll();
            return View("NoticeList", result);
        }

        public ActionResult NoticeList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<NoticeModel> result = new List<NoticeModel>();
                NoticeDAO noticeDAO = new NoticeDAO();
                result = noticeDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewNoticeObject(NoticeModel noticeModel)
        {
            NoticeDAO noticeDAO = new NoticeDAO();
            noticeModel.PostDate = DateTime.Now;
            noticeDAO.CreateOrUpdateRecord(noticeModel);

            return View("NoticeDetails", noticeModel);
        }

        public ActionResult NoticeDetails(int id)
        {
            NoticeDAO noticeDAO = new NoticeDAO();
            NoticeModel result = noticeDAO.FetchOne(id);
            return View("NoticeDetails", result);
        }

        ///Accomodation
        public ActionResult AccomodationCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                return View();
            }
        }

        public ActionResult AccomodationEdit(int id)
        {
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            AccomodationModel accomodationModel = accomodationDAO.FetchOne(id);
            return View("AccomodationCreate", accomodationModel);
        }

        public ActionResult AccomodationDelete(int id)
        {
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            accomodationDAO.DeleteRecord(id);
            List<AccomodationModel> result = accomodationDAO.FetchAll();
            return View("AccomodationList", result);
        }

        public ActionResult AccomodationList()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<AccomodationModel> result = new List<AccomodationModel>();
                AccomodationDAO accomodationDAO = new AccomodationDAO();
                result = accomodationDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewAccomodationObject(AccomodationModel accomodationModel)
        {
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            accomodationDAO.CreateOrUpdateRecord(accomodationModel);

            return View("AccomodationDetails", accomodationModel);
        }

        public ActionResult AccomodationDetails(int id)
        {
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            AccomodationModel result = accomodationDAO.FetchOne(id);
            return View("AccomodationDetails", result);
        }



        ///Student Associations
        public ActionResult StudentAssociationsCreate()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }
            else
            {
                return View();
            }
        }

        public ActionResult StudentAssociationsEdit(int Id)
        {
            AssociationsDAO associationsDAO = new AssociationsDAO();
            AssociationsModel associationsModel = associationsDAO.FetchOne(Id);
            return View("StudentAssociationsCreate", associationsModel);
        }

        public ActionResult StudentAssociationsDelete(int id)
        {
            AssociationsDAO associationsDAO = new AssociationsDAO();
            associationsDAO.DeleteRecord(id);
            List<AssociationsModel> result = associationsDAO.FetchAll();
            return View("StudentAssociations", result);
        }

        public ActionResult StudentAssociations()
        {
            if (IsLoggedIn() == false)
            {
                ViewBag.Message = ("Please login");
                return View("LoginForm");
            }

            else
            {
                List<AssociationsModel> result = new List<AssociationsModel>();
                AssociationsDAO associationsDAO = new AssociationsDAO();
                result = associationsDAO.FetchAll();

                return View(result);
            }
        }

        public ActionResult NewAssociationsObject(AssociationsModel associationsModel)
        {
            AssociationsDAO associationsDAO = new AssociationsDAO();
            associationsDAO.CreateOrUpdateRecord(associationsModel);

            return View("StudentAssociationsDetails", associationsModel);
        }

        public ActionResult AssociationsDetails(int id)
        {
            AssociationsDAO associationsDAO = new AssociationsDAO();
            AssociationsModel result = associationsDAO.FetchOne(id);
            return View("StudentAssociationsDetails", result);
        }
    }
}