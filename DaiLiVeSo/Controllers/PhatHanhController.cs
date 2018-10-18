using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace DaiLiVeSo.Controllers
{
    public class PhatHanhController : Controller
    {
        // GET: PhatHanh
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new PhatHanhDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }

        public void SetViewBagMaLoaiVe(string selectedId = null)
        {
            var dao = new PhatHanhDao();
            ViewBag.MaLoaiVeSo = new SelectList(dao.ListAllMaLoaiVe(), "MaLoaiVeSo", "Tinh", selectedId);
        }

        public void SetViewBagMaDaiLy(string selectedId = null)
        {
            var dao = new PhatHanhDao();
            ViewBag.MaDaiLy = new SelectList(dao.ListAllMaDaiLy(), "MaDaiLy", "TenDaiLy", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var pt = new PhatHanhDao().GetById(id);
            SetViewBagMaLoaiVe(pt.MaLoaiVeSo);
            SetViewBagMaDaiLy(pt.MaDaiLy);
            return View(pt);
        }

        [HttpPost]
        public ActionResult Edit(PhatHanh pt)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhatHanhDao();
                pt.Flag = true;
                var result = dao.Update(pt);
                if (result)
                {
                    return RedirectToAction("Index", "PhatHanh");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa phát hành không thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new PhatHanhDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(string id)
        {
            new PhatHanhDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}