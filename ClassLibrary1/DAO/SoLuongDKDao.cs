using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class SoLuongDKDao
    {
        QLVESODbContext db = null;
        public SoLuongDKDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<SoLuongDK> listAll(int page, int pageSize)
        {
            return db.SoLuongDKs.OrderByDescending(x => x.NgayDK).OrderBy(x => x.ID).OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public string Insert(SoLuongDK entity)
        {
            db.SoLuongDKs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public SoLuongDK GetById(string id)
        {
            return db.SoLuongDKs.SingleOrDefault(x => x.ID == id);
        }
        public bool Update(SoLuongDK kq)
        {
            try
            {
                var tempt = db.SoLuongDKs.Find(kq.ID);
                tempt.MaDaiLy = kq.MaDaiLy;
                tempt.SoLuongDK1 = kq.SoLuongDK1;
                tempt.NgayDK = kq.NgayDK;                
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
                db.SoLuongDKs.Find(id).Flag = false;
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
                db.SoLuongDKs.Find(id).Flag = true;
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
            var countrow = db.SoLuongDKs.Count();
            int getcount = countrow + 1;
            string newmahd = "DK";
            if (getcount < 10) newmahd = newmahd + "00" + getcount.ToString();
            else if (getcount < 100) newmahd = newmahd + "0" + getcount.ToString();
            return newmahd;
        }
    }
}
