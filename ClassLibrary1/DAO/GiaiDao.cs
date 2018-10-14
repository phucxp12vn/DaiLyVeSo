
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;


namespace Model.DAO
{
    public class GiaiDao
    {
        QLVESODbContext db = null;
        public GiaiDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<Giai> listAll(int page, int pageSize)
        {
            return db.Giais.OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public string Insert (Giai entity )
        {
            db.Giais.Add(entity);
            db.SaveChanges();
            return entity.MaGiai;
        }
        public Giai GetById(string MaGiai)
        {
            return db.Giais.SingleOrDefault(x => x.MaGiai == MaGiai);
        }
        public bool Update (Giai giai)
        {
           try
            {
                var tempt = db.Giais.Find(giai.MaGiai);
                tempt.TenGiai = giai.TenGiai;
                tempt.SoTienNhan = giai.SoTienNhan;
                tempt.Flag = giai.Flag;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete (string MaGiai)
        {
            try
            {
                db.Giais.Find(MaGiai).Flag = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnDelete(string MaGiai)
        {
            try
            {
                db.Giais.Find(MaGiai).Flag = true;
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
