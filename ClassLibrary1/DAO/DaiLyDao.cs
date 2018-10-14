using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;

namespace Model.DAO
{
   public class DaiLyDao
    {
        QLVESODbContext db = null;
        public DaiLyDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<DaiLy> listAll(int page, int pageSize)
        {
            return db.DaiLies.OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public string Insert(DaiLy entity)
        {
            db.DaiLies.Add(entity);
            db.SaveChanges();
            return entity.MaDaiLy;
        }
        public DaiLy GetById(string MaDaiLy)
        {
            return db.DaiLies.SingleOrDefault(x => x.MaDaiLy == MaDaiLy);
        }
        public bool Update(DaiLy dl)
        {
            try
            {
                var tempt = db.DaiLies.Find(dl.MaDaiLy);
                tempt.TenDaiLy = dl.TenDaiLy;
                tempt.DiaChi = dl.DiaChi;
                tempt.SDT = dl.SDT;
                tempt.Flag = dl.Flag;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string MaDaiLy)
        {
            try
            {
                db.DaiLies.Find(MaDaiLy).Flag = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnDelete(string MaDaiLy)
        {
            try
            {
                db.DaiLies.Find(MaDaiLy).Flag = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
