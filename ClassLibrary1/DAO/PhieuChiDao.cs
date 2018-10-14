using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class PhieuChiDao
    {
        QLVESODbContext db = null;
        public PhieuChiDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<PhieuChi> listAll(int page, int pageSize)
        {
            return db.PhieuChis.OrderByDescending(x => x.Ngay).ToPagedList(page, pageSize);
        }
        public string Insert(PhieuChi entity)
        {
            db.PhieuChis.Add(entity);
            db.SaveChanges();
            return entity.MaPhieuChi;
        }
        public PhieuChi GetById(string id)
        {
            return db.PhieuChis.SingleOrDefault(x => x.MaPhieuChi == id);
        }
        public bool Update(PhieuChi pc)
        {
            try
            {
                var tempt = db.PhieuChis.Find(pc.MaPhieuChi);
                tempt.SoTien = pc.SoTien;
                tempt.Ngay = pc.Ngay;
                tempt.NoiDung = pc.NoiDung;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var pc = db.PhieuChis.Find(id);
                db.PhieuChis.Remove(pc);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }       

        public String AutoGetMa()
        {
            var countrow = db.PhieuChis.Count();
            int getcount = countrow + 1;
            string newmahd = "PCH";
            if (getcount < 10) newmahd = newmahd + "000" + getcount.ToString();
            else if (getcount < 100) newmahd = newmahd + "00" + getcount.ToString();
            return newmahd;
        }
    }
}
