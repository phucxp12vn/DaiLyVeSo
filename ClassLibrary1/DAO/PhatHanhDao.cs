using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class PhatHanhDao
    {
        QLVESODbContext db = null;
        public PhatHanhDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<PhatHanh> listAll(int page, int pageSize)
        {
            return db.PhatHanhs.OrderByDescending(x => x.NgayNhan).ToPagedList(page, pageSize);
        }
        public string Insert(PhatHanh entity)
        {
            db.PhatHanhs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public PhatHanh GetById(string id)
        {
            return db.PhatHanhs.SingleOrDefault(x => x.ID == id);

        }
        public bool Update(PhatHanh pt)
        {
            try
            {
                var tempt = db.PhatHanhs.Find(pt.ID);
                tempt.MaLoaiVeSo = pt.MaLoaiVeSo;
                tempt.MaDaiLy = pt.MaDaiLy;
                tempt.SoLuong = pt.SoLuong;
                tempt.TienThanhToan = pt.TienThanhToan;
                tempt.SLBan = pt.SLBan;
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
                db.PhatHanhs.Find(id).Flag = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnDelete(string id)
        {
            try
            {
                db.PhatHanhs.Find(id).Flag = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<LoaiVeso> ListAllMaLoaiVe()
        {
            return db.LoaiVesoes.Where(x => x.Flag == true).ToList();
        }

        public List<DaiLy> ListAllMaDaiLy()
        {
            return db.DaiLies.Where(x => x.Flag == true).ToList();
        }
        public String AutoGetMa()
        {
            var countrow = db.PhatHanhs.Count();
            int getcount = countrow + 1;
            string newmahd = "PH";
            if (getcount < 10) newmahd = newmahd + "000" + getcount.ToString();
            else if (getcount < 100) newmahd = newmahd + "00" + getcount.ToString();
            return newmahd;
        }
    }
}
