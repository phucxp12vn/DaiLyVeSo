using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class KetQuaDao
    {
        QLVESODbContext db = null;
        public KetQuaDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<KetQuaSoXo> listAll(int page, int pageSize)
        {
            return db.KetQuaSoXoes.OrderByDescending(x => x.NgaySo).OrderBy(x => x.ID).OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public int Insert(KetQuaSoXo entity)
        {
            db.KetQuaSoXoes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public KetQuaSoXo GetById(int id)
        {
            return db.KetQuaSoXoes.Find(id);
        }
        public bool Update(KetQuaSoXo kq)
        {
            try
            {
                var tempt = db.KetQuaSoXoes.Find(kq.ID);
                tempt.MaLoaiVeSo = kq.MaLoaiVeSo;
                tempt.MaGiai = kq.MaGiai;
                tempt.SoTrung = kq.SoTrung;
                tempt.NgaySo = kq.NgaySo;                
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
                db.KetQuaSoXoes.Find(id).Flag = false;
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
                db.KetQuaSoXoes.Find(id).Flag = true;
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

        public List<Giai> ListAllMaGiai()
        {
            return db.Giais.Where(x => x.Flag == true).ToList();
        }
    }
}
