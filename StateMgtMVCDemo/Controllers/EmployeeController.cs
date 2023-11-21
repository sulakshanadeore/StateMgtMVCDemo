using StateMgtMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateMgtMVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        static List<EmpModel> emplist = new List<EmpModel>() 
        {
            new EmpModel { Empid=1,EmpName="Saj",City="Pune",Deptno=10},
            new EmpModel {Empid=2,EmpName="Amit",City="Pune",Deptno=10 },
            new EmpModel { Empid=3,EmpName="Sumit",City="Pune",Deptno=20},
            new EmpModel { Empid=4,EmpName="Kamal",City="Pune",Deptno=30},
            new EmpModel { Empid=5,EmpName="vimal",City="Pune",Deptno=20} 
        };
        // GET: Employee
        public ActionResult Index()//List of employees
        {
            //View with list template
            ViewBag.empCount=emplist.Count;
              
            return View(emplist);
        }

        public ActionResult SearchByDeptNo()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SearchByDeptNo(int deptno)
        {
            TempData["deptdata"] = deptno;
            return RedirectToAction("EmpDetail");

        }


        public ActionResult EmpDetail()
        {
            int id=Convert.ToInt32(TempData["deptdata"]);
            List<EmpModel> employeesInDept = emplist.FindAll(e => e.Deptno == id);
            TempData.Keep();
            return View(employeesInDept);
        }

        public ActionResult PassData()
        {
            
            TempData["passDeptno"] = Convert.ToInt32(TempData.Peek("deptdata"));
            //  return RedirectToAction("ShowDeptDetails", "Department");
            return RedirectToAction("UsingParameter", "Department", new { id = Convert.ToInt32(TempData["passDeptno"]) });

        }


       


    }
}