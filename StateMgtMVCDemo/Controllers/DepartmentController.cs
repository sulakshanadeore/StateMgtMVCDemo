using StateMgtMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateMgtMVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        static List<DeptModel> deptlist = new List<DeptModel>() 
        {
        new DeptModel{Deptno=10,Dname="Logistics",Loc="Pune" },
        new DeptModel{ Deptno=20,Dname="Development",Loc="Pune" },
         new DeptModel{ Deptno=30,Dname="Training",Loc="Pune" },
        new DeptModel{ Deptno=40,Dname="HR",Loc="Pune" },
         };
        // GET: Department
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ShowDeptDetails()
        {
            int id = Convert.ToInt32(TempData["passDeptno"]);
            DeptModel details=deptlist.Find(d => d.Deptno == id);
            return View(details);
        
        
        }


        public ActionResult UsingParameter(int id)
        {
            
            DeptModel details = deptlist.Find(d => d.Deptno == id);
            return View(details);

        }

    }
}