using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class PhieuThuDao
    {
        QLVESODbContext db = null;
        public PhieuThuDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<PhieuThu> listAll(int page, int pageSize)
        {
            return db.PhieuThus.OrderByDescending(x => x.NgayNop).OrderBy(x => x.MaPhieuThu).OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public string Insert(PhieuThu entity)
        {
            db.PhieuThus.Add(entity);
            db.SaveChanges();
            return entity.MaPhieuThu;
        }
        public PhieuThu GetById(string id)
        {
            return db.PhieuThus.SingleOrDefault(x => x.MaPhieuThu == id);
        }
        public bool Update(PhieuThu pt)
        {
            try
            {
                var tempt = db.PhieuThus.Find(pt.MaPhieuThu);
                tempt.MaDaiLy = pt.MaDaiLy;
                tempt.SoTienNop = pt.SoTienNop;
                tempt.NgayNop = pt.NgayNop;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                db.PhieuThus.Find(id).Flag = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnDelete(int id)
        {
            try
            {
                db.PhieuThus.Find(id).Flag = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<DaiLy> ListAllMaDaiLy()
        {
            return db.DaiLies.Where(x => x.Flag == true).ToList();
        }
        public String AutoGetMa()
        {
            var countrow = db.PhieuThus.Count();
            int getcount = countrow + 1;
            string newmahd = "PTH";
            if (getcount < 10) newmahd = newmahd + "000" + getcount.ToString();
            else if (getcount < 100) newmahd = newmahd + "00" + getcount.ToString();
            return newmahd;
        }
    }
}
