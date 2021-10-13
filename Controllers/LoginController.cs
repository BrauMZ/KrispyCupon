using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using KrispyCupon.Models;

namespace KrispyCupon.Controllers

{

    public class LoginController : Controller
    {
       
        database_Access_Layer.db dblayer = new database_Access_Layer.db();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(FormCollection fc)
        {
            int res = dblayer.Admin_Login(fc ["txtUsuario"], fc ["txtPassword"]);
            if (res==1)
            {
                TempData["msg"] = "Bienvenido";
                
                Session["usuariologueado"] = fc["txtUsuario"];
                return RedirectToAction("Index", "Cupon");
                
            }
            else
            {
                TempData["msg"] = "Datos Invalidos, Intente Nuevamente";
                return View();
            }
        }


    }
}