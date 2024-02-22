using API_Basic.Entities;

namespace API_Basic.Helper
{
    public class InputHelper
    {
        public static bool KiemTraDoDaiChuoi(string chuoi, int maxLength)
        {
            return chuoi.Length > maxLength;
        }

        public static bool KiemTraSoTu(string chuoi, int min)
        {
            return chuoi.Split(' ').Length >= min;
        }
        public static bool KiemtraThongTinHocSinhHopLe(HocSinh hocSinh)
        {
            if (hocSinh.NgaySinh.Year < 2001 || hocSinh.NgaySinh.Year > 2013)
            {
                Console.WriteLine("Tuoi Khong Hop Le!");
                return false;
            }
            if (!KiemTraSoTu(hocSinh.HoTen, 2))
            {
                Console.WriteLine("Ho Ten Qua Ngan!");
                return false;
            }
            if (KiemTraDoDaiChuoi(hocSinh.HoTen, 20))
            {
                Console.WriteLine("Ho Ten Qua Dai!");
                return false;
            }
            return true;
        }
    }
}
