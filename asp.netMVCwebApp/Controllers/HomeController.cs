using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netMVCwebApp.Entity;
using asp.netMVCwebApp.IoCContainer;
using asp.netMVCwebApp.Model;

namespace asp.netMVCwebApp.Controllers
{
    public class HomeController : Controller
    {

        UserRepository _repUser = RepositoryFactory<UserRepository>.GetRepositoryInstance();

        public ActionResult Index()
        {
            return View();
        }//end method

        //
        // POST: /Register/Create
        [HttpPost]
        public JsonResult Index(User userInfo)
        {


            User existUser = _repUser.GetSingle(u => u.Email == userInfo.Email);
            if (existUser != null)
            {
                return Json(new { success = false, message = "Bu e-posta adresi ile daha önce kayıt olunmuş. Lütfen farklı e-posta giriniz." });

            }//End If

            userInfo.CreatedDate = DateTime.Now;

            OperationResult opResult = _repUser.AddItem(userInfo);
            if (opResult.IsFailed)
            {
                return Json(new { success = false, message = "Yeni Kullanıcı ekleme hatası.Detay: " + opResult.ErrorMessage });
            }//End if
            return Json(new { success = true });

        }//End Method 




    }//end class
}//end namespace