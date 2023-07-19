using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TEST_JAIRO_QUEVEDO.ViewModels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TEST_JAIRO_QUEVEDO.ApiRequest;

namespace TEST_JAIRO_QUEVEDO.Controllers
{
    public class HomeController : Controller
    {
        string apiUrl1 = "http://dummy.restapiexample.com/api/v1/employees";
        string apiUrl2 = "http://dummy.restapiexample.com/api/v1/employee/";
        public ActionResult index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            ApiMethods apiMethods = new ApiMethods();
            if(apiMethods.Employees(apiUrl1) != null)
            {
                return Json(apiMethods.Employees(apiUrl1), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public JsonResult GetEmployee(int id)
        {
            ApiMethods apiMethods = new ApiMethods();
            if (apiMethods.Employee(apiUrl2, id) != null)
            {
                return Json(apiMethods.Employee(apiUrl2, id), JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}