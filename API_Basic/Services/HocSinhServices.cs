using API_Basic.Constant;
using API_Basic.Entities;
using API_Basic.Helper;
using API_Basic.IServices;
using Microsoft.EntityFrameworkCore;

namespace API_Basic.Services
{
    public class HocSinhServices : IHocSinhServices
    {
        private readonly AppDbContext dbContext;
        public HocSinhServices()
        {
            dbContext = new AppDbContext();
        }
        private void CapNhatSiSo(int lopId)
        {
            var lopHienTai = dbContext.Lops.FirstOrDefault(x => x.LopId == lopId);
            if (lopHienTai != null)
            {
                lopHienTai.SiSo = dbContext.HocSinhs.Count(x => x.LopId == lopHienTai.LopId);
                dbContext.Update(lopHienTai);
                dbContext.SaveChanges();

            }
        }
        public ErrorMessage ChuyenLopChoHocSinh(int hocSinhId, int lopCuId, int lopMoiId)
        {
            if (!dbContext.Lops.Any(x => x.LopId == lopCuId))
            {
                return ErrorMessage.LopKhongTontai;
            }
            if (!dbContext.Lops.Any(x => x.LopId == lopMoiId))
            {
                return ErrorMessage.LopKhongTontai;
            }
            var hocSinhHienTai = dbContext.HocSinhs.FirstOrDefault(x => x.HocSinhId == hocSinhId);
            if (hocSinhHienTai != null)
            {

                hocSinhHienTai.LopId = lopMoiId;
                dbContext.Update(hocSinhHienTai);
                dbContext.SaveChanges();
                CapNhatSiSo(lopCuId);
                CapNhatSiSo(lopMoiId);
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }

        public ErrorMessage SuaThongTinHocSinh(HocSinh hocsinh)
        {
            var hocSinhHienTai = dbContext.HocSinhs.FirstOrDefault(x => x.HocSinhId == hocsinh.HocSinhId);
            if (hocSinhHienTai != null)
            {
                if (!InputHelper.KiemtraThongTinHocSinhHopLe(hocsinh))
                {
                    return ErrorMessage.DuLieuSai;
                }
                hocSinhHienTai.HoTen = hocsinh.HoTen;
                hocSinhHienTai.NgaySinh = hocsinh.NgaySinh;
                hocSinhHienTai.QueQuan = hocsinh.QueQuan;
                dbContext.Update(hocSinhHienTai);
                dbContext.SaveChanges();
                return ErrorMessage.ThanhCong;
            }
            else
            {
                return ErrorMessage.ThatBai;
            }
        }

        public ErrorMessage ThemHocSinhVaoLop(HocSinh hocsinh, int lopId)
        {
            if (!InputHelper.KiemtraThongTinHocSinhHopLe(hocsinh))
            {
                return ErrorMessage.DuLieuSai;
            }
            if (dbContext.HocSinhs.Any(x => x.HocSinhId == hocsinh.HocSinhId))
            {
                return ErrorMessage.HocSinhDaTonTai;
            }
            else
            {
                //them hoc sinh
                if (dbContext.Lops.Any(x => x.LopId == lopId))
                {
                    // them hoc sinh vao lop
                    var lopHienTai = dbContext.Lops.FirstOrDefault(x => x.LopId == lopId);
                    if (lopHienTai.SiSo + 1 > 20)
                    {
                        return ErrorMessage.SiSoToiDa;
                    }
                    else
                    {
                        hocsinh.Lop = null; 
                        hocsinh.LopId = lopId;
                        dbContext.HocSinhs.Add(hocsinh);
                        dbContext.SaveChanges();
                        CapNhatSiSo(lopId);
                        return ErrorMessage.ThanhCong;

                    }
                }
                else
                {
                    return ErrorMessage.ThatBai;
                }
            }
        }

        public ErrorMessage XoaHocSinh(int hocSinhId)
        {
            var hocSinhHienTai = dbContext.HocSinhs.FirstOrDefault(x => x.HocSinhId == hocSinhId);
            if (hocSinhHienTai != null)
            {

                dbContext.Remove(hocSinhHienTai);
                dbContext.SaveChanges();
                CapNhatSiSo(hocSinhHienTai.LopId);
                return ErrorMessage.ThanhCong;
            }
            else
            {
                Console.WriteLine("Hoc sinh khong ton tai!");
                return ErrorMessage.ThatBai;
            }
        }

        public IEnumerable<HocSinh> GetDsHocSinh()
        {
            return dbContext.HocSinhs.AsQueryable();
        }
    }
}
