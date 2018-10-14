using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace DaiLiVeSo.Controllers
{
    public class DaiLyController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DaiLyDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dl = new DaiLyDao().GetById(id);

            return View(dl);
        }

        [HttpPost]
        public ActionResult Edit(DaiLy dl)
        {
            if (ModelState.IsValid)
            {
                var dao = new DaiLyDao();
                dl.Flag = true;
                var result = dao.Update(dl);
                if (result)
                {
                    return RedirectToAction("Index", "DaiLy");
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
        public ActionResult Create(DaiLy dl)
        {
            if (ModelState.IsValid)
            {
                var dao = new DaiLyDao();
                dl.Flag = true;
                string result = dao.Insert(dl);
                if (result != null)
                {
                    return RedirectToAction("Index", "DaiLy");
                }
            }
            else
            {
                //return RedirectToAction("Create", "DaiLy");
                ModelState.AddModelError("", "Thêm giải mới không thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DaiLyDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(string id)
        {
            new DaiLyDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}