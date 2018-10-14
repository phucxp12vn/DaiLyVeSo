
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace DaiLiVeSo.Controllers
{
    public class KetQuaController : Controller
    {
        // GET: KetQua
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new KetQuaDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }

        public void SetViewBagMaLoaiVe(string selectedId = null)
        {
            var dao = new KetQuaDao();
            ViewBag.MaLoaiVeSo = new SelectList(dao.ListAllMaLoaiVe(), "MaLoaiVeSo", "Tinh", selectedId);
        } 

        public void SetViewBagMaGiai(string selectedId = null)
        {
            var dao = new KetQuaDao();
            ViewBag.MaGiai = new SelectList(dao.ListAllMaGiai(), "MaGiai", "TenGiai", selectedId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kq = new KetQuaDao().GetById(id);
            SetViewBagMaLoaiVe(kq.MaLoaiVeSo);
            SetViewBagMaGiai(kq.MaGiai);
            return View(kq);
        }

        [HttpPost]
        public ActionResult Edit(KetQuaSoXo kq)
        {
            if (ModelState.IsValid)
            {
                var dao = new KetQuaDao();
                kq.Flag = true;
                var result = dao.Update(kq);
                if (result)
                {
                    return RedirectToAction("Index", "KetQua");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chỉnh sửa giải không thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KetQuaDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(int id)
        {
            new KetQuaDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}