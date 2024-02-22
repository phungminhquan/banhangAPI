using API_Basic.Constant;
using API_Basic.Entities;

namespace API_Basic.IServices
{
    public interface IHocSinhServices
    {
        ErrorMessage ThemHocSinhVaoLop(HocSinh hocsinh, int lopId);
        ErrorMessage SuaThongTinHocSinh(HocSinh hocsinh);
        ErrorMessage XoaHocSinh(int hocSinhId);
        ErrorMessage ChuyenLopChoHocSinh(int hocSinhId, int lopCuId, int lopMoiId);
        IEnumerable<HocSinh> GetDsHocSinh();
    }
}
