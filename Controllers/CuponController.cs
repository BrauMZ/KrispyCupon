using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrispyCupon.Models;
using KrispyCupon.Extensions;

namespace KrispyCupon.Controllers
{
    public class CuponController : Controller
    {
        database_Access_Layer.dbCupon dblayer = new database_Access_Layer.dbCupon();
        // GET: User

        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult Listar()
        {
            List<Cupon> oListaCupones = new List<Cupon>();

            using (KrispyKremeEntities db = new KrispyKremeEntities())
            {
                oListaCupones = (from c in db.Cupon select c).ToList();
            }
            return Json(new { data = oListaCupones }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Obtener(int idcode)
        {
            Cupon oCupon = new Cupon();

            using (KrispyKremeEntities db = new KrispyKremeEntities())
            {

                oCupon = (from p in db.Cupon.Where(x => x.idcode == idcode)
                            select p).FirstOrDefault();
            }
            
            return Json(oCupon, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Cupon oCupon)
        {
            bool respuesta = true;
            string mensaje = "";
            if (oCupon.idcode == 0)
            {
                try
                {
                    DateTime dtVigencia = oCupon.vigencia;
                    string sVigencia = dtVigencia.ToString("yyyy-MM-dd");
                    dtVigencia = Convert.ToDateTime(sVigencia);
                    string sSucursal = oCupon.sucursal;
                    string sDescripcion = oCupon.descripcion;
                    int nCantidad = oCupon.cantidad;
                    bool bEstatus = oCupon.estatus;
                    string sUser = Convert.ToString(@Session["usuariologueado"]);

                    int n = 0;
                    while (n < nCantidad)
                    {
                        mensaje = dblayer.Registra_Cupon(sVigencia, sSucursal, bEstatus, sDescripcion, sUser);
                        n++;
                    }
                }
                catch
                {
                    respuesta = false;
                }
            }
            else
            {
                try
                {
                    int nIcode = oCupon.idcode;
                    DateTime dtVigencia = oCupon.vigencia;
                    string sVigencia = dtVigencia.ToString("yyyy-MM-dd");
                    dtVigencia = Convert.ToDateTime(sVigencia);
                    string sDescripcion = oCupon.descripcion;
                    bool bEstatus = oCupon.estatus;
                    string sUser = Convert.ToString(@Session["usuariologueado"]);
                        
                    mensaje = dblayer.Update_Cupon(nIcode, sVigencia, bEstatus, sDescripcion, sUser);
                }
                catch
                {
                    respuesta = false;
                }
            }

            this.AddNotification(mensaje, NotificationType.SUCCESS);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int idcode)
        {
            bool respuesta = true;
            string mensaje = "";
            try
            {
                int nIdcode = idcode;
                string sUser = Convert.ToString(@Session["usuariologueado"]);

                mensaje = dblayer.Delete_Cupon(nIdcode, sUser);
            }
            catch
            {
                respuesta = false;
            }
            this.AddNotification(mensaje, NotificationType.SUCCESS);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


    }
}