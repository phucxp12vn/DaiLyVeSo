using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace DaiLiVeSo.Controllers
{
    public class PhieuThuController : Controller
    {
        // GET: PhieuThu
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new PhieuThuDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }

        public void SetViewBagMaDaiLy(string selectedId = null)
        {
            var dao = new PhieuThuDao();
            ViewBag.MaDaiLy = new SelectList(dao.ListAllMaDaiLy(), "MaDaiLy", "TenDaiLy", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var sl = new PhieuThuDao().GetById(id);
            SetViewBagMaDaiLy(sl.MaDaiLy);
            return View(sl);
        }

        [HttpPost]
        public ActionResult Edit(PhieuThu pt)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuThuDao();
                pt.Flag = true;
                var result = dao.Update(pt);
                if (result)
                {
                    return RedirectToAction("Index", "PhieuThu");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa phiếu thu không thành công");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagMaDaiLy();
            PhieuThu dk = new PhieuThu();
            var dao = new PhieuThuDao();
            dk.NgayNop = DateTime.Now;
            dk.MaPhieuThu = dao.AutoGetMa();
            return View(dk);
        }


        [HttpPost]
        public ActionResult Create(PhieuThu pt)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuThuDao();
                pt.Flag = true;
                string result = dao.Insert(pt);
                if (result != null)
                {
                    return RedirectToAction("Index", "PhieuThu");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm phiếu thu mới không thành công");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PhieuThuDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(int id)
        {
            new PhieuThuDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}