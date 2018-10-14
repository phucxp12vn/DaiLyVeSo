using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace DaiLiVeSo.Controllers
{
    public class PhieuChiController : Controller
    {
        // GET: PhieuChi
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new PhieuChiDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var sl = new PhieuChiDao().GetById(id);
            return View(sl);
        }

        [HttpPost]
        public ActionResult Edit(PhieuChi pc)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuChiDao();
                var result = dao.Update(pc);
                if (result)
                {
                    return RedirectToAction("Index", "PhieuChi");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa phiếu chi không thành công");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            PhieuChi dk = new PhieuChi();
            var dao = new PhieuChiDao();
            dk.Ngay = DateTime.Now;
            dk.MaPhieuChi = dao.AutoGetMa();
            return View(dk);
        }


        [HttpPost]
        public ActionResult Create(PhieuChi pc)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuChiDao();
                string result = dao.Insert(pc);
                if (result != null)
                {
                    return RedirectToAction("Index", "PhieuChi");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm phiếu chi mới không thành công");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new PhieuChiDao().Delete(id);
            return RedirectToAction("Index");

        }


    }


}