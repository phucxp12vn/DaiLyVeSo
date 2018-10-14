using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaiLiVeSo.Controllers
{
    public class GiaiController : Controller
    {
        // GET: Giai
        public ActionResult Index(int page = 1,int pageSize= 10)
        {
            var dao = new GiaiDao();
            var model = dao.listAll(page,pageSize);
            return View(model);
        }

     

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var giai = new GiaiDao().GetById(id);

            return View(giai);
        }

        [HttpPost]
        public ActionResult Edit(Giai giai)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiaiDao();
                giai.Flag = true;
                var result = dao.Update(giai);
                if (result)
                {
                    return RedirectToAction("Index", "Giai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa giải không thành công");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Giai giai)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiaiDao();
                giai.Flag = true;
                string result = dao.Insert(giai);
                if (result != null)
                {
                    return RedirectToAction("Index", "Giai");
                }
            }
            else
            {
                //return RedirectToAction("Create", "Giai");
                ModelState.AddModelError("", "Thêm giải mới không thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new GiaiDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(string id)
        {
            new GiaiDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}