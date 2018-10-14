using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;

namespace Model.DAO
{
    public class LoaiVeSoDao
    {
        QLVESODbContext db = null;
        public LoaiVeSoDao()
        {
            db = new QLVESODbContext();
        }
        public IEnumerable<LoaiVeso> listAll(int page, int pageSize)
        {
            return db.LoaiVesoes.OrderByDescending(x => x.Flag).ToPagedList(page, pageSize);
        }
        public string Insert(LoaiVeso entity)
        {
            db.LoaiVesoes.Add(entity);
            db.SaveChanges();
            return entity.MaLoaiVeSo;
        }
        public LoaiVeso GetById(string MaLoai)
        {
            return db.LoaiVesoes.SingleOrDefault(x => x.MaLoaiVeSo == MaLoai);
        }
        public bool Update(LoaiVeso loai)
        {
            try
            {
                var tempt = db.LoaiVesoes.Find(loai.MaLoaiVeSo);
                tempt.Tinh = loai.Tinh;
                tempt.Flag = loai.Flag;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string MaLoai)
        {
            try
            {
                db.LoaiVesoes.Find(MaLoai).Flag = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UnDelete(string MaLoai)
        {
            try
            {
                db.LoaiVesoes.Find(MaLoai).Flag = true;
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
