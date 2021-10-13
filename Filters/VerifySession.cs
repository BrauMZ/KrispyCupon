using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrispyCupon.Controllers;
using KrispyCupon.Models;

namespace KrispyCupon.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var oUser = (sp_ValidaUsers_Result)HttpContext.Current.Session["usuariologueado"];

            if (oUser == null)
            {
                if(filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}