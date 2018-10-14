using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace DaiLiVeSo.Controllers
{
    public class LoaiVeSoController : Controller
    {
        // GET: LoaiVeSo
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new LoaiVeSoDao();
            var model = dao.listAll(page, pageSize);
            return View(model);
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            var loai = new LoaiVeSoDao().GetById(id);

            return View(loai);
        }

        [HttpPost]
        public ActionResult Edit(LoaiVeso loai)
        {
            if (ModelState.IsValid)
            {
                loai.Flag = true; 
                var dao = new LoaiVeSoDao();
                var result = dao.Update(loai);
                if (result)
                {
                    return RedirectToAction("Index", "LoaiVeSo");
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
        public ActionResult Create(LoaiVeso loai)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiVeSoDao();
                loai.Flag = true;
                string result = dao.Insert(loai);
                if (result != null)
                {
                    return RedirectToAction("Index", "LoaiVeSo");
                }
            }
            else
            {
                //return RedirectToAction("Create", "LoaiVeSo");
                ModelState.AddModelError("", "Thêm loại vé mới không thành công");
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new LoaiVeSoDao().Delete(id);
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public ActionResult UnDelete(string id)
        {
            new LoaiVeSoDao().UnDelete(id);
            return RedirectToAction("Index");

        }
    }
}