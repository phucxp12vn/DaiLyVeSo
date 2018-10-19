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
                if(pt.SLBan != null)
                {
                    pt.DoanhThuDPH = pt.SLBan * pt.SLBan;
                    pt.TienThanhToan = pt.DoanhThuDPH * (1 - (pt.HoaHong / 100));
                }
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

        [HttpGet]
        public ActionResult Create()
        {
            var pt = new PhatHanh();
            var dao = new PhatHanhDao();
            pt.ID = dao.AutoGetMa();
            pt.NgayNhan = DateTime.Now;
            pt.HoaHong =  10;
            SetViewBagMaLoaiVe();
            SetViewBagMaDaiLy();
            return View(pt);
        }

        [HttpPost]
        public ActionResult Create(PhatHanh phatHanh)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhatHanhDao();
                phatHanh.Flag = true;
                if(phatHanh.SoLuong == null)
                {
                    decimal slg = TinhToanSLPhatTheoDaiLy(phatHanh.MaDaiLy, phatHanh.MaLoaiVeSo, (DateTime)phatHanh.NgayNhan);
                    phatHanh.SoLuong = (int)slg;
                }
                string result = dao.Insert(phatHanh);
                if (result != null)
                {
                    return RedirectToAction("Index", "PhatHanh");
                }
            }
            else
            {
                //return RedirectToAction("Create", "PhatHanh");
                ModelState.AddModelError("", "Thêm loại vé mới không thành công");
            }
            return View("Index");
        }


        public decimal TinhToanSLPhatTheoDaiLy(string MaDaiLy, string MaLoaiVeSo, System.DateTime NgayNhan)
        {
            var dao = new QLVESODbContext();
            decimal SLDK = dao.SoLuongDKs.OrderByDescending(m => m.NgayDK).Where(m => m.MaDaiLy == MaDaiLy & System.DateTime.Compare((DateTime) m.NgayDK, NgayNhan) <= 0).Select(m => (int)m.SoLuongDK1).FirstOrDefault();
            var listTop3 = dao.PhatHanhs.OrderByDescending(m => m.NgayNhan).Where(m => m.MaDaiLy == MaDaiLy  & m.SLBan != null).ToList().Take(3);
            int count = listTop3.Count();
            if (count == 0)
            {
                return SLDK;
            }
            else
            {
                decimal sum = 0;
                foreach (var item in listTop3)
                {
                    decimal a = (decimal)item.SLBan;
                    decimal b = (decimal)item.SoLuong;
                    sum += a / b;
                }
                decimal? getReturn = Math.Round(((decimal)sum * SLDK) / count );
                return getReturn ?? default(decimal);
            }
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