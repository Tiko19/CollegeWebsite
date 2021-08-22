using CollegeWebsite.Data;
using CollegeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<NoticeModel> result = new List<NoticeModel>();
            NoticeDAO noticeDAO = new NoticeDAO();
            result = noticeDAO.FetchAll();
            return View(result);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult FacultyList()
        {
            List<FacultyModel> result = new List<FacultyModel>();
            FacultyDAO facultyDAO = new FacultyDAO();
            result = facultyDAO.FetchAll();

            return View(result);
        }

        public ActionResult BachelorList()
        {
            List<ProgramsModel> result = new List<ProgramsModel>();
            BachelorDAO bachelorDAO = new BachelorDAO();
            result = bachelorDAO.FetchAll();

            return View(result);
        }

        public ActionResult MasterList()
        {
            List<ProgramsModel> result = new List<ProgramsModel>();
            MasterDAO masterDAO = new MasterDAO();
            result = masterDAO.FetchAll();

            return View(result);
        }

        public ActionResult NonDegreeList()
        {
            List<ProgramsModel> result = new List<ProgramsModel>();
            NonDegreeDAO nonDegreeDAO = new NonDegreeDAO();
            result = nonDegreeDAO.FetchAll();

            return View(result);
        }

        public ActionResult DatesDeadlinesList()
        {
            List<DeadlineModel> result = new List<DeadlineModel>();
            DeadlineDAO deadlineDAO = new DeadlineDAO();
            result = deadlineDAO.FetchAll();

            return View(result);
        }

        public ActionResult AccomodationList()
        {
            List<AccomodationModel> result = new List<AccomodationModel>();
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            result = accomodationDAO.FetchAll();

            return View(result);
        }

        public ActionResult ApplicationProcedure()
        {
            return View();
        }

        public ActionResult EligibilityRequirements()
        {
            return View();
        }

        public ActionResult EstimatedCosts()
        {
            List<AccomodationModel> result = new List<AccomodationModel>();
            AccomodationDAO accomodationDAO = new AccomodationDAO();
            result = accomodationDAO.FetchAll();

            return View(result);
        }

        public ActionResult EntryVisa()
        {
            return View();
        }

        public ActionResult FinanceInfo()
        {
            return View();
        }

        public ActionResult Arrival()
        {
            return View();
        }

        public ActionResult ChineseScholarship()
        {
            return View();
        }

        public ActionResult IIEScholarship()
        {
            return View();
        }

        public ActionResult Undergraduates()
        {
            return View();
        }

        public ActionResult Postgraduates()
        {
            return View();
        }

        public ActionResult AcademicRegulations()
        {
            return View();
        }


        public ActionResult RulesRegulations()
        {
            return View();
        }

        public ActionResult Insurance()
        {
            return View();
        }

        public ActionResult ResidencePermit()
        {
            return View();
        }

        public ActionResult CampusService()
        {
            return View();
        }

        public ActionResult StudentsUnion()
        {
            return View();
        }

        public ActionResult StudentsAssociations()
        {
            List<AssociationsModel> result = new List<AssociationsModel>();
            AssociationsDAO associationsDAO = new AssociationsDAO();
            result = associationsDAO.FetchAll();

            return View(result);
        }
    }
}