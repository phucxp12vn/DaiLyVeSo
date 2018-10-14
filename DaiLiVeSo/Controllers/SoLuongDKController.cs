using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;


namespace DaiLiVeSo.Controllers
{
    public class SoLuongDKController : Controller
    {
        // GET: SoLuongDK
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SoLuongDKDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }

        public void SetViewBagMaDaiLy(string selectedId = null)
        {
            var dao = new SoLuongDKDao();
            ViewBag.MaDaiLy = new SelectList(dao.ListAllMaDaiLy(), "MaDaiLy", "TenDaiLy", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var sl = new SoLuongDKDao().GetById(id);
            SetViewBagMaDaiLy(sl.MaDaiLy);
            return View(sl);
        }

        [HttpPost]
        public ActionResult Edit(SoLuongDK sl)
        {
            if (ModelState.IsValid)
            {
                var dao = new SoLuongDKDao();
                sl.Flag = true;
                var result = dao.Update(sl);
                if (result)
                {
                    return RedirectToAction("Index", "SoLuongDK");
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
            SetViewBagMaDaiLy();
            SoLuongDK dk = new SoLuongDK();
            var dao = new SoLuongDKDao();
            dk.NgayDK = DateTime.Now;
            dk.ID = dao.AutoGetMa();
            return View(dk);
        }


        [HttpPost]
        public ActionResult Create(SoLuongDK sl)
        {
            if (ModelState.IsValid)
            {
                var dao = new SoLuongDKDao();
                sl.Flag = true;
                string result = dao.Insert(sl);
                if (result != null)
                {
                    return RedirectToAction("Index", "SoLuongDK");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm giải mới không thành công");
            }
            return View("Index");
        }
      
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SoLuongDKDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(int id)
        {
            new SoLuongDKDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}